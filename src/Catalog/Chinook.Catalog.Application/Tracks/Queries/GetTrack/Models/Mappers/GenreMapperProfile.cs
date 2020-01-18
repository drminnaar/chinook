using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    public sealed class GenreMapperProfile : Profile
    {
        public GenreMapperProfile()
        {
            CreateMap<Genre, TrackGenre>();
        }
    }
}
