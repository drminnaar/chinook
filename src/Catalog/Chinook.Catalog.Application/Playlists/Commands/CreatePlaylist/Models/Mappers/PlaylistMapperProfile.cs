using AutoMapper;
using Chinook.Catalog.Domain.Models;

namespace Chinook.Catalog.Application.Playlists.Commands.CreatePlaylist.Models
{
    public sealed class PlaylistMapperProfile : Profile
    {
        public PlaylistMapperProfile()
        {
            CreateMap<CreatePlaylistCommand, Playlist>();
            CreateMap<Playlist, PlaylistFromCreate>();
        }
    }
}
