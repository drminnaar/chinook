using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models;
using Chinook.Catalog.Domain.Models;
using MediatR;

namespace Chinook.Catalog.Application.Tracks.Commands.CreateTrack
{
    public sealed class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, TrackFromCreate>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMapper _mapper;

        public CreateTrackCommandHandler(ICatalogDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<TrackFromCreate> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var track = _mapper.Map<Track>(request);

            _context.Tracks.Add(track);

            async Task<TrackFromCreate> AddTrackAsync()
            {
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<TrackFromCreate>(track);
            }

            return AddTrackAsync();
        }
    }
}
