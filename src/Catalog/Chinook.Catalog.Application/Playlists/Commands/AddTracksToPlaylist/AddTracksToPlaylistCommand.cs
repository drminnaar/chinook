using System;
using System.Collections.Generic;
using MediatR;

namespace Chinook.Catalog.Application.Playlists.CommandsAddTracksToPlaylist
{
    public sealed class AddTracksToPlaylistCommand : IRequest
    {
        public AddTracksToPlaylistCommand(int playlistId, IReadOnlyCollection<int> trackIds)
        {
            PlaylistId = playlistId;
            TrackIds = trackIds ?? throw new ArgumentNullException(nameof(trackIds));
        }

        public int PlaylistId { get; }
        public IReadOnlyCollection<int> TrackIds { get; }
    }
}
