using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application.Tracks.Commands.UpdateTrack
{
    public sealed class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand>
    {
        private readonly ICatalogDbContext _context;

        public UpdateTrackCommandHandler(ICatalogDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            async Task<Unit> UpdateTrackAsync()
            {
                var trackFromDb = await _context
                    .Tracks
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == request.TrackId);

                if (trackFromDb == null)
                    throw new EntityNotFoundException($"A track having id '{request.TrackId}' could not be found");

                trackFromDb.AlbumId = request.AlbumId;
                trackFromDb.Bytes = request.AlbumId;
                trackFromDb.Composer = request.Composer;
                trackFromDb.GenreId = request.GenreId;
                trackFromDb.MediaTypeId = request.MediaTypeId;
                trackFromDb.Milliseconds = request.Milliseconds;
                trackFromDb.Name = request.Name;
                trackFromDb.UnitPrice = request.Price;

                var entriesSaved = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            return UpdateTrackAsync();
        }
    }
}
