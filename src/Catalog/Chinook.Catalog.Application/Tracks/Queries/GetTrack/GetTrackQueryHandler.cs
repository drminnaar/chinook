using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack
{
    public sealed class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, TrackDetail>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMapper _mapper;

        public GetTrackQueryHandler(ICatalogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<TrackDetail> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            async Task<TrackDetail> GetTrackById()
            {
                var trackFromDb = await _context
                    .Tracks
                    .TagWithQueryName(nameof(GetTrackById))
                    .AsNoTracking()
                    .Where(e => e.Id == request.TrackId)
                    .Include(track => track.Genre)
                    .Include(track => track.Album!.Artist)
                    .Include(track => track.MediaType)
                    .Include(track => track.Compositions)
                    .ThenInclude(playlistTrack => playlistTrack.Playlist)
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

                return _mapper.Map<TrackDetail>(trackFromDb);
            }

            return GetTrackById();
        }
    }
}
