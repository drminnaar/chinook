using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    [DataContract(Name = "Artist", Namespace = "http://example.com/chinook")]
    public sealed class TrackArtist
    {
        /// <summary>
        /// A unique integer based on artist identifier
        /// </summary>
        /// <example>2342349</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Name of artist
        /// </summary>
        /// <example>MPEG audio file</example>
        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
