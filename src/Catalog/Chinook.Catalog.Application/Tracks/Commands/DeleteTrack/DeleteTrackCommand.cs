using MediatR;

namespace Chinook.Catalog.Application.Tracks.Commands.DeleteTrack
{
    public sealed class DeleteTrackCommand : IRequest
    {
        public DeleteTrackCommand()
        {
        }

        public DeleteTrackCommand(int trackId)
        {
            TrackId = trackId;
        }

        public int TrackId { get; }
    }
}
