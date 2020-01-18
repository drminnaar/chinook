using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class GetPlaylistQueryHandler : IRequestHandler<GetPlaylistQuery, PlaylistDetail?>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMapper _mapper;

        public GetPlaylistQueryHandler(ICatalogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<PlaylistDetail?> Handle(GetPlaylistQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetPlaylistById(request.PlaylistId);
        }

        private async Task<PlaylistDetail?> GetPlaylistById(int playlistId)
        {
            var playlistFromDb = await _context
                .Playlists
                .TagWithQueryName(nameof(GetPlaylistById))
                .Where(playlist => playlist.Id == playlistId)
                .Include(playlist => playlist.PlaylistTracks)
                .FirstOrDefaultAsync();

            return playlistFromDb == null ? null : _mapper.Map<PlaylistDetail>(playlistFromDb);
        }
    }
}
