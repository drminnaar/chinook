using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    public sealed class MediaTypeMapperProfile : Profile
    {
        public MediaTypeMapperProfile()
        {
            CreateMap<MediaType, TrackMediaType>();
        }
    }
}
