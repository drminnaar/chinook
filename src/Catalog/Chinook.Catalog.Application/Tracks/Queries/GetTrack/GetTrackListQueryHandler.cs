using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Filters;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models;
using Chinook.Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack
{
    public sealed class GetTrackListQueryHandler : IRequestHandler<GetTrackListQuery, IPagedCollection<TrackDetail>>
    {
        private readonly ICatalogDbContext _context;
        private readonly ITrackFilterBuilder _filterBuilder;
        private readonly IEntityOrderBuilder<Track> _orderBuilder;
        private readonly IMapper _mapper;

        public GetTrackListQueryHandler(
            ICatalogDbContext context,
            ITrackFilterBuilder filterBuilder,
            IEntityOrderBuilder<Track> orderBuilder,
            IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _filterBuilder = filterBuilder ?? throw new ArgumentNullException(nameof(filterBuilder));
            _orderBuilder = orderBuilder ?? throw new ArgumentNullException(nameof(orderBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IPagedCollection<TrackDetail>> Handle(GetTrackListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return GetTrackList(request);
        }

        private async Task<IPagedCollection<TrackDetail>> GetTrackList(GetTrackListQuery request)
        {
            var filter = _filterBuilder
                .WhereAlbumLike(request.Album)
                .WhereArtistLike(request.Artist)
                .WhereComposerLike(request.Composer)
                .WhereGenreLike(request.Genre)
                .WhereMediaTypeLike(request.MediaType)
                .WhereNameLike(request.Name)
                .WherePrice(request.PriceFrom, request.PriceTo)
                .WherePlaylistIdEquals(request.PlaylistId)
                .Filter;

            var tracksFromDb = await _context
                .Tracks
                .TagWithQueryName(nameof(GetTrackList))
                .AsNoTracking()
                .Where(filter)
                .Include(track => track.Genre)
                .Include(track => track.Album!.Artist)
                .Include(track => track.MediaType)
                .OrderBy(request.Order, _orderBuilder)
                .ToPagedCollectionAsync(request.PageNumber, request.PageSize);

            var tracks = _mapper.Map<IReadOnlyList<TrackDetail>>(tracksFromDb);

            return new PagedCollection<TrackDetail>(
                tracks,
                tracksFromDb.ItemCount,
                tracksFromDb.CurrentPageNumber,
                tracksFromDb.PageSize);
        }
    }
}
