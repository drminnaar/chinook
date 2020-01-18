using System.Collections.Generic;

namespace Chinook.Catalog.Domain.Models
{
    public sealed class Track
    {
        public int Id { get; set; }
        public string? Composer { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Bytes { get; set; }
        public int Milliseconds { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
        public int MediaTypeId { get; set; }
        public MediaType? MediaType { get; set; }
        public ICollection<PlaylistTrack> PlaylistTracks { get; } = new HashSet<PlaylistTrack>();
    }
}
