using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class GetPlaylistListQueryHandler : IRequestHandler<GetPlaylistListQuery, IPagedCollection<PlaylistDetail>>
    {
        private readonly ICatalogDbContext _context;
        private readonly IPlaylistFilterBuilder _filterBuilder;
        private readonly IEntityOrderBuilder<Playlist> _orderBuilder;
        private readonly IMapper _mapper;

        public GetPlaylistListQueryHandler(
            ICatalogDbContext context,
            IPlaylistFilterBuilder filterBuilder,
            IEntityOrderBuilder<Playlist> orderBuilder,
            IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _filterBuilder = filterBuilder ?? throw new ArgumentNullException(nameof(filterBuilder));
            _orderBuilder = orderBuilder ?? throw new ArgumentNullException(nameof(orderBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IPagedCollection<PlaylistDetail>> Handle(GetPlaylistListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetPlaylistsList(request);
        }

        private async Task<IPagedCollection<PlaylistDetail>> GetPlaylistsList(GetPlaylistListQuery request)
        {
            var filter = _filterBuilder
                .WhereTrackIdEquals(request.TrackId)
                .WhereNameLike(request.Name).Filter;

            var playlistsFromDb = await _context
                .Playlists
                .TagWithQueryName(nameof(GetPlaylistsList))
                .Where(filter)
                .Include(e => e.PlaylistTracks)
                .OrderBy(request.Order, _orderBuilder)
                .ToPagedCollectionAsync(request.PageNumber, request.PageSize);

            var playlists = _mapper.Map<IReadOnlyList<PlaylistDetail>>(playlistsFromDb);

            return new PagedCollection<PlaylistDetail>(
                playlists,
                playlistsFromDb.ItemCount,
                playlistsFromDb.CurrentPageNumber,
                playlistsFromDb.PageSize);
        }
    }
}
