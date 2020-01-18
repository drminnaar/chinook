using System;
using System.Collections.Generic;
using Chinook.Catalog.Application.Playlists.Commands.UpdatePlaylist.Models;
using MediatR;

namespace Chinook.Catalog.Application.Playlists.Commands.UpdatePlaylist
{
    public sealed class UpdatePlaylistCommand : IRequest
    {
        public UpdatePlaylistCommand(int playlistId, PlaylistForUpdate playlist)
        {
            if (playlist is null)
                throw new ArgumentNullException(nameof(playlist));

            Name = playlist.Name;
            PlaylistId = playlistId;
            TrackIds = playlist.TrackIds;
        }

        public string Name { get; }
        public int PlaylistId { get; }
        public IReadOnlyCollection<int> TrackIds { get; }
    }
}
