using System;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models
{
    public sealed class TrackForCreate
    {
        [Required(ErrorMessage = "Track name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Composer is required")]
        public string Composer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 5, ErrorMessage = "Price should be set at 0-5")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bytes is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Bytes should be greater than 0")]
        public int Bytes { get; set; }

        [Required(ErrorMessage = "Milliseconds is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Milliseconds should be greater than 0")]
        public int Milliseconds { get; set; }

        [Required(ErrorMessage = "Album id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Album id is required")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Genre id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Genre id is required")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Media type id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Media type id is required")]
        public int MediaTypeId { get; set; }
    }
}
