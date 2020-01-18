using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Commands.DeletePlaylist
{
    public sealed class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand>
    {
        private readonly ICatalogDbContext _context;

        public DeletePlaylistCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return DeletePlaylistAsync(request.PlaylistId, cancellationToken);
        }

        private async Task<Unit> DeletePlaylistAsync(int playlistId, CancellationToken cancellationToken)
        {
            var playlist = await _context
                .Playlists
                .FirstOrDefaultAsync(playlist => playlist.Id == playlistId);

            if (playlist == null)
                throw new EntityNotFoundException($"A playlist having id '{playlistId}' could not be found");

            var playlistTracks = await _context
                .PlaylistTracks
                .Where(e => e.PlaylistId == playlistId)
                .ToListAsync();

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress))
            {
                _context.PlaylistTracks.RemoveRange(playlistTracks);
                _context.Playlists.Remove(playlist);

                var entries = await _context.SaveChangesAsync(cancellationToken);
                if (entries != (playlistTracks.Count + 1))
                    throw new DbUpdateException($"Something went wrong while attempting to remove playlist having id '{playlistId}'");

                scope.Complete();
            }

            return Unit.Value;
        }
    }
}
