using System.Collections.Generic;
using MediatR;

namespace Chinook.Catalog.Application.Playlists.Commands.DeleteTracksFromPlaylist
{
    public sealed class DeleteTracksFromPlaylistCommand : IRequest
    {
        public DeleteTracksFromPlaylistCommand(int playlistId, IReadOnlyCollection<int> trackIds)
        {
            PlaylistId = playlistId;
            TrackIds = trackIds;
        }

        public int PlaylistId { get; }
        public IReadOnlyCollection<int> TrackIds { get; }
    }
}
