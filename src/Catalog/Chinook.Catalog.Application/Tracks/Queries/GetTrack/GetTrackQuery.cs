using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models;
using MediatR;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack
{
    public sealed class GetTrackQuery : IRequest<TrackDetail>
    {
        public GetTrackQuery()
        {
        }

        public GetTrackQuery(int trackId)
        {
            TrackId = trackId;
        }

        public int TrackId { get; }
    }
}
