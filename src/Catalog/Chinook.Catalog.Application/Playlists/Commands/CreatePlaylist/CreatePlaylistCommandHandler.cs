using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Playlists.Commands.CreatePlaylist.Models;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Commands.CreatePlaylist
{
    public sealed class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, PlaylistFromCreate>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMapper _mapper;

        public CreatePlaylistCommandHandler(ICatalogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<PlaylistFromCreate> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return CreatePlaylistAsync(request, cancellationToken);
        }

        private async Task<PlaylistFromCreate> CreatePlaylistAsync(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var trackIds = await NormalizeTrackIds(request.TrackIds);

            var playlist = _mapper.Map<Playlist>(request);
            trackIds.ForEach(trackId => playlist.PlaylistTracks.Add(new PlaylistTrack { TrackId = trackId }));

            _context.Playlists.Add(playlist);

            var entriesSaved = await _context.SaveChangesAsync(cancellationToken);
            var expectedEntriesSaved = trackIds.Count + 1;
            if (entriesSaved != expectedEntriesSaved)
                throw new DbUpdateException($"While adding a new playlist, received '{entriesSaved}' saved entries, but expected '{expectedEntriesSaved}'");

            return _mapper.Map<PlaylistFromCreate>(playlist);
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
