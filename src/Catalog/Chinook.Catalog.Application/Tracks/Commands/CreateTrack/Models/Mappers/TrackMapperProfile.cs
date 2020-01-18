using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models
{
    public sealed class TrackMapperProfile : Profile
    {
        public TrackMapperProfile()
        {
            CreateMap<CreateTrackCommand, Track>();
            CreateMap<Track, TrackFromCreate>()
                .ForMember(destination =>
                    destination.Price,
                    options => options.MapFrom(source => source.UnitPrice));
        }
    }
}
