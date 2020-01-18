using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models
{
    [DataContract(Name = "Playlist", Namespace = "http://example.com/chinook")]
    public sealed class PlaylistDetail
    {
        /// <summary>
        /// A unique integer based on playlist identifier
        /// </summary>
        /// <example>83488</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// The name of playlist
        /// </summary>
        /// <example>Grunge</example>
        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Number of tracks in playlist
        /// </summary>
        /// <example>Grunge</example>
        [DataMember(Order = 3)]
        public int TrackCount { get; set; }
    }
}
