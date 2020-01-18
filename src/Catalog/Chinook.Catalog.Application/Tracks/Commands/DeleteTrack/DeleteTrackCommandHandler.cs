using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Commands.DeleteTrack
{
    public sealed class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand>
    {
        private readonly ICatalogDbContext _context;

        public DeleteTrackCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            async Task<Unit> Handle()
            {
                var track = await _context
                    .Tracks
                    .AsNoTracking()
                    .FirstOrDefaultAsync(track => track.Id == request.TrackId);

                if (track == null)
                    throw new DbUpdateException($"Delete track failed. A track having id '{request.TrackId}' could not be found");

                _context.Tracks.Remove(track);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            return Handle();
        }
    }
}
