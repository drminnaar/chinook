using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    [DataContract(Name = "MediaType", Namespace = "http://example.com/chinook")]
    public sealed class TrackMediaType
    {
        /// <summary>
        /// A unique integer based on mediatype identifier
        /// </summary>
        /// <example>2342349</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Name of media type
        /// </summary>
        /// <example>MPEG audio file</example>
        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
