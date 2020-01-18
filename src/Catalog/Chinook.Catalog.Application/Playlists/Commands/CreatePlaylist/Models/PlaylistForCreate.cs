using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Playlists.Commands.CreatePlaylist.Models
{
    [DataContract(Name = "Playlist", Namespace = "http://example.com/chinook")]
    public sealed class PlaylistForCreate
    {
        /// <summary>
        /// The name of playlist
        /// </summary>
        /// <example>Grunge</example>
        [DataMember(Order = 1)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// List of track ids to associate with playlist
        /// </summary>
        /// <example>123,456,67890</example>
        [DataMember(Order = 2)]
        public IReadOnlyCollection<int> TrackIds { get; set; } = new List<int>();
    }
}
