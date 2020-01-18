using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Orders
{
    public sealed class TrackOrderBuilder : EntityOrderBuilderBase<Track>
    {
        protected override IDictionary<string, Expression<Func<Track, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Track, object>>>()
            {
                { "name", e => e.Name },
                { "composer", e => e.Composer ?? string.Empty },
                { "unit-price", e => e.UnitPrice },
                { "genre", e => e.Genre!.Name },
                { "album", e => e.Album!.Title },
                { "artist", e => e.Album!.Artist!.Name },
                { "bytes", e => e.Bytes },
                { "milliseconds", e => e.Milliseconds },
                { "media-type", e => e.MediaType!.Name }
            };
        }
    }
}
