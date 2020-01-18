using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    [DataContract(Name = "Genre", Namespace = "http://example.com/chinook")]
    public sealed class TrackGenre
    {
        /// <summary>
        /// A unique integer based on genre identifier
        /// </summary>
        /// <example>2342349</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Name of genre
        /// </summary>
        /// <example>Rock</example>
        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
