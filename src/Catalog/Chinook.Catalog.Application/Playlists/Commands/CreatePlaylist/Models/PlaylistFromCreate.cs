using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Playlists.Commands.CreatePlaylist.Models
{
    [DataContract(Name = "Playlist", Namespace = "http://example.com/chinook")]
    public sealed class PlaylistFromCreate
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
    }
}
