using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    public sealed class ArtistMapperProfile : Profile
    {
        public ArtistMapperProfile()
        {
            CreateMap<Artist, TrackArtist>();
        }
    }
}
