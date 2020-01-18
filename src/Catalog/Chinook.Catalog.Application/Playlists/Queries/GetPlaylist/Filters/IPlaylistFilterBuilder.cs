using System;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public interface IPlaylistFilterBuilder
    {
        Expression<Func<Playlist, bool>> Filter { get; }

        IPlaylistFilterBuilder WhereNameLike(string? name);
        IPlaylistFilterBuilder WhereTrackIdEquals(int? trackId);
    }
}
