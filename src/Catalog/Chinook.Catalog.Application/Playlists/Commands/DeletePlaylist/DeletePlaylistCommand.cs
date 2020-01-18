using MediatR;

namespace Chinook.Catalog.Application.Playlists.Commands.DeletePlaylist
{
    public sealed class DeletePlaylistCommand : IRequest
    {
        public DeletePlaylistCommand()
        {
        }

        public DeletePlaylistCommand(int playlistId)
        {
            PlaylistId = playlistId;
        }

        public int PlaylistId { get; }
    }
}
