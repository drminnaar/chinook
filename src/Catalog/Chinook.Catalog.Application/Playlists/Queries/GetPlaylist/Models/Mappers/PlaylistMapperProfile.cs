using System.Collections.Generic;
using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models
{
    public sealed class PlaylistMapperProfile : Profile
    {
        public PlaylistMapperProfile()
        {
            CreateMap<Playlist, PlaylistDetail>()
                .ForMember(destination =>
                    destination.TrackCount,
                    options => options.MapFrom(source => source.PlaylistTracks.Count));

            CreateMap<IPagedCollection<Playlist>, List<PlaylistDetail>>();
        }
    }
}
