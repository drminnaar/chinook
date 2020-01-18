using System;
using Chinook.Catalog.Application.Tracks.Commands.UpdateTrack.Models;
using MediatR;

namespace Chinook.Catalog.Application.Tracks.Commands.UpdateTrack
{
    public sealed class UpdateTrackCommand : IRequest
    {
        public UpdateTrackCommand()
        {
        }

        public UpdateTrackCommand(int trackId, TrackForUpdate track)
        {
            if (track is null)
                throw new ArgumentNullException(nameof(track));

            AlbumId = track.AlbumId;
            Bytes = track.Bytes;
            Composer = track.Composer;
            GenreId = track.GenreId;
            MediaTypeId = track.MediaTypeId;
            Milliseconds = track.Milliseconds;
            Name = track.Name;
            Price = track.Price;
            TrackId = trackId;
        }

        public int TrackId { get; }
        public string Name { get; } = string.Empty;
        public string Composer { get; } = string.Empty;
        public decimal Price { get; }
        public int Bytes { get; }
        public int Milliseconds { get; }
        public int AlbumId { get; }
        public int GenreId { get; }
        public int MediaTypeId { get; }
    }
}
