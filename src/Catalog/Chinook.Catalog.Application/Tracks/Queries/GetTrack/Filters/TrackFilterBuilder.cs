using System;
using System.Linq;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Filters
{
    public sealed class TrackFilterBuilder : ITrackFilterBuilder
    {
        public Expression<Func<Track, bool>> Filter { get; private set; } = ExpressionBuilder.True<Track>();

        public ITrackFilterBuilder WhereAlbumLike(string? album)
        {
            if (!string.IsNullOrWhiteSpace(album))
                Filter = Filter.And(e => EF.Functions.ILike(e.Album!.Title, $"%{album}%"));

            return this;
        }

        public ITrackFilterBuilder WhereArtistLike(string? artist)
        {
            if (!string.IsNullOrWhiteSpace(artist))
                Filter = Filter.And(e => EF.Functions.ILike(e.Album!.Artist!.Name, $"%{artist}%"));

            return this;
        }

        public ITrackFilterBuilder WhereComposerLike(string? composer)
        {
            if (!string.IsNullOrWhiteSpace(composer))
                Filter = Filter.And(e => EF.Functions.ILike(e.Composer, $"%{composer}%"));

            return this;
        }

        public ITrackFilterBuilder WhereGenreLike(string? genre)
        {
            if (!string.IsNullOrWhiteSpace(genre))
                Filter = Filter.And(e => EF.Functions.ILike(e.Genre!.Name, $"%{genre}%"));

            return this;
        }

        public ITrackFilterBuilder WhereMediaTypeLike(string? mediaType)
        {
            if (!string.IsNullOrWhiteSpace(mediaType))
                Filter = Filter.And(e => EF.Functions.ILike(e.MediaType!.Name, $"%{mediaType}%"));

            return this;
        }

        public ITrackFilterBuilder WhereNameLike(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Filter = Filter.And(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            return this;
        }

        public ITrackFilterBuilder WherePlaylistIdEquals(int? playlistId)
        {
            if (playlistId > 0)
                Filter = Filter.And(e => e.Compositions.Select(e => e.PlaylistId).Contains(playlistId.Value));

            return this;
        }

        public ITrackFilterBuilder WherePrice(PriceFilter? fromPrice, PriceFilter? toPrice)
        {
            if (fromPrice != null)
                Filter = Filter.And(fromPrice.Expression());

            if (toPrice != null)
                Filter = Filter.And(toPrice.Expression());

            return this;
        }
    }


}
