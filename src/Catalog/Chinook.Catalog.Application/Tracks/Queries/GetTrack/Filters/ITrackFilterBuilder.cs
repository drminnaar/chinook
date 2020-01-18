using System;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Filters
{
    public interface ITrackFilterBuilder
    {
        Expression<Func<Track, bool>> Filter { get; }

        ITrackFilterBuilder WhereAlbumLike(string? album);
        ITrackFilterBuilder WhereArtistLike(string? artist);
        ITrackFilterBuilder WhereComposerLike(string? composer);
        ITrackFilterBuilder WhereGenreLike(string? genre);
        ITrackFilterBuilder WhereMediaTypeLike(string? mediaType);
        ITrackFilterBuilder WhereNameLike(string? name);
        ITrackFilterBuilder WherePlaylistIdEquals(int? playlistId);
        ITrackFilterBuilder WherePrice(PriceFilter? fromPrice, PriceFilter? toPrice);
    }
}
