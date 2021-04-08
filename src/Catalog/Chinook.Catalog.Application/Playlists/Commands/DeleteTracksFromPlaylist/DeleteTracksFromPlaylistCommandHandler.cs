using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Commands.DeleteTracksFromPlaylist
{
    public sealed class DeleteTracksFromPlaylistCommandHandler : IRequestHandler<DeleteTracksFromPlaylistCommand>
    {
        private readonly ICatalogDbContext _context;

        public DeleteTracksFromPlaylistCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(DeleteTracksFromPlaylistCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return DeleteTracksFromPlaylistAsync(request.PlaylistId, request.TrackIds, cancellationToken);
        }

        private async Task<Unit> DeleteTracksFromPlaylistAsync(
            int playlistId,
            IReadOnlyCollection<int> trackIds,
            CancellationToken cancellationToken)
        {
            var validTrackIds = await ValidateTrackIds(playlistId, trackIds);
            var playlistTracksFromDb = await _context
                .PlaylistTracks
                .Where(playlist => playlist.PlaylistId == playlistId && validTrackIds.Contains(playlist.TrackId))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
            _context.PlaylistTracks.RemoveRange(playlistTracksFromDb);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        private async Task<List<int>> ValidateTrackIds(int playlistId, IReadOnlyCollection<int> trackIds)
        {
            var uniqueTrackIds = trackIds
                .Distinct()
                .OrderBy(trackId => trackId)
                .ToList();

            if (trackIds != null && trackIds.Any())
            {
                var playlistTrackIdsFromDb = await _context
                    .PlaylistTracks
                    .AsNoTracking()
                    .Where(playlist => playlist.PlaylistId == playlistId && uniqueTrackIds.Contains(playlist.TrackId))
                    .Select(playlist => playlist.TrackId)
                    .OrderBy(trackId => trackId)
                    .ToListAsync();

                if (!playlistTrackIdsFromDb.SequenceEqual(uniqueTrackIds))
                {
                    var missingTrackIds = string.Join(",", uniqueTrackIds.Except(playlistTrackIdsFromDb));
                    throw new EntityNotFoundException($"Tracks having ids '{missingTrackIds}' do not exist");
                }
            }

            return uniqueTrackIds;
        }
    }
}
