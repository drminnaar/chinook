using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class PlaylistOrderBuilder : EntityOrderBuilderBase<Playlist>
    {
        protected override IDictionary<string, Expression<Func<Playlist, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Playlist, object>>>()
            {
                { "name", e => e.Name }
            };
        }
    }
}
