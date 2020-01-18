using System.Collections.Generic;

namespace Chinook.Catalog.Domain.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; } = new HashSet<PlaylistTrack>();
    }
}
