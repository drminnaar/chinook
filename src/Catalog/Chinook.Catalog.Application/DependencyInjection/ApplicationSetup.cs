using System.Reflection;
using AutoMapper;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Filters;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Orders;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Catalog.Application.DependencyInjection
{
    public static class ApplicationSetup
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddScoped<ITrackFilterBuilder, TrackFilterBuilder>()
                .AddScoped<IPlaylistFilterBuilder, PlaylistFilterBuilder>()
                .AddScoped<IEntityOrderBuilder<Track>, TrackOrderBuilder>()
                .AddScoped<IEntityOrderBuilder<Playlist>, PlaylistOrderBuilder>();
        }
    }
}
