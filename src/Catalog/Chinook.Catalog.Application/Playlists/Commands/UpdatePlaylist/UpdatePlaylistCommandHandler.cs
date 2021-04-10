using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Commands.UpdatePlaylist
{
    public sealed class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand>
    {
        private readonly ICatalogDbContext _context;

        public UpdatePlaylistCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return UpdatePlaylistAsync(request, cancellationToken);
        }

        private async Task<Unit> UpdatePlaylistAsync(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var playlistFromDb = await _context
                .Playlists
                .FirstOrDefaultAsync(e => e.Id == request.PlaylistId, cancellationToken)
                .ConfigureAwait(false);

            if (playlistFromDb == null)
                throw new EntityNotFoundException($"A playlist having id '{request.PlaylistId}' could not be found");

            var currentPlaylistTracks = await _context
                .Compositions
                .Where(pt => pt.PlaylistId == playlistFromDb.Id)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var newPlaylistTracks = (await NormalizeTrackIds(request.TrackIds))
                .Select(trackId => new Composition { PlaylistId = playlistFromDb.Id, TrackId = trackId });

            _context.Compositions.RemoveRange(currentPlaylistTracks);
            _context.Compositions.AddRange(newPlaylistTracks);
            playlistFromDb.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<List<int>> NormalizeTrackIds(IReadOnlyCollection<int> trackIds)
        {
            var normalizedTrackIds = trackIds
                ?.Distinct()
                .OrderBy(trackId => trackId)
                .ToList()
                ?? new List<int>(0);

            if (trackIds != null && trackIds.Any())
            {
                var trackIdsFromDb = await _context
                    .Tracks
                    .AsNoTracking()
                    .Where(track => trackIds.Contains(track.Id))
                    .Select(track => track.Id)
                    .OrderBy(trackId => trackId)
                    .ToListAsync();

                if (!trackIdsFromDb.SequenceEqual(normalizedTrackIds))
                {
                    var invalidTrackIds = string.Join(",", normalizedTrackIds.Except(trackIdsFromDb));
                    throw new InvalidOperationException($"Tracks having ids '{invalidTrackIds}' do not exist");
                }
            }

            return normalizedTrackIds;
        }
    }
}
