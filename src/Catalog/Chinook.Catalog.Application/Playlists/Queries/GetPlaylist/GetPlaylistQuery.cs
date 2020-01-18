using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models;
using MediatR;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class GetPlaylistQuery : IRequest<PlaylistDetail?>
    {
        public GetPlaylistQuery()
        {
        }

        public GetPlaylistQuery(int playlistId)
        {
            PlaylistId = playlistId;
        }

        public int PlaylistId { get; }
    }
}
