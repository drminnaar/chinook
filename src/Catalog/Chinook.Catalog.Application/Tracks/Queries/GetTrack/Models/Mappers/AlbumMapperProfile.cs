using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    public sealed class AlbumMapperProfile : Profile
    {
        public AlbumMapperProfile()
        {
            CreateMap<Album, TrackAlbum>();
        }
    }
}
