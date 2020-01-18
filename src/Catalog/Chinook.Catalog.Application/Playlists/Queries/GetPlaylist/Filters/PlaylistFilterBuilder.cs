using System;
using System.Linq;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class PlaylistFilterBuilder : IPlaylistFilterBuilder
    {
        public Expression<Func<Playlist, bool>> Filter { get; private set; } = ExpressionBuilder.True<Playlist>();

        public IPlaylistFilterBuilder WhereNameLike(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Filter = Filter.And(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            return this;
        }

        public IPlaylistFilterBuilder WhereTrackIdEquals(int? trackId)
        {
            if (trackId.HasValue)
                Filter = Filter.And(playlist => playlist.PlaylistTracks.Select(playlistTrack => playlistTrack.TrackId).Contains(trackId.Value));

            return this;
        }
    }
}
