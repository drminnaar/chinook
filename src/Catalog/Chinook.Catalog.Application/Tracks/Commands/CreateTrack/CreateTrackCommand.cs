using System;
using Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models;
using MediatR;

namespace Chinook.Catalog.Application.Tracks.Commands.CreateTrack
{
    public sealed class CreateTrackCommand : IRequest<TrackFromCreate>
    {
        public CreateTrackCommand()
        {
        }

        public CreateTrackCommand(TrackForCreate track)
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
        }

        public string Name { get; set; } = string.Empty;
        public string Composer { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Bytes { get; set; }
        public int Milliseconds { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int MediaTypeId { get; set; }
    }
}
