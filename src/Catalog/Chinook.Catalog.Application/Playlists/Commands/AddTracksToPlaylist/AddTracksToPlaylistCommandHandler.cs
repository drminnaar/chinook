using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.CommandsAddTracksToPlaylist
{
    public sealed class AddTracksToPlaylistCommandHandler : IRequestHandler<AddTracksToPlaylistCommand>
    {
        private readonly ICatalogDbContext _context;

        public AddTracksToPlaylistCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(AddTracksToPlaylistCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return AddTracksToPlaylistAsync(request.PlaylistId, request.TrackIds, cancellationToken);
        }

        private async Task<Unit> AddTracksToPlaylistAsync(
            int playlistId,
            IReadOnlyCollection<int> trackIds,
            CancellationToken cancellationToken)
        {
            var playlistFromDb = await _context
                .Playlists
                .FirstOrDefaultAsync(e => e.Id == playlistId, cancellationToken)
                .ConfigureAwait(false);

            if (playlistFromDb == null)
                throw new EntityNotFoundException($"A playlist having id '{playlistId}' could not be found");

            var newTrackIds = trackIds
                .Distinct()
                .OrderBy(trackId => trackId)
                .ToList();

            var existingTrackIds = await _context
                .PlaylistTracks
                .AsNoTracking()
                .Where(pt => pt.PlaylistId == playlistId && newTrackIds.Contains(pt.TrackId))
                .Select(pt => pt.TrackId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var tracksForAdd = newTrackIds
                .Except(existingTrackIds)
                .Select(trackId => new PlaylistTrack { PlaylistId = playlistId, TrackId = trackId })
                .ToList();

            if (tracksForAdd.Any())
            {
                _context.PlaylistTracks.AddRange(tracksForAdd);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
