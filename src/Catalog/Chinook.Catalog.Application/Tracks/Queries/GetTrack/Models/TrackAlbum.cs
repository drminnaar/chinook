using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    [DataContract(Name = "Album", Namespace = "http://example.com/chinook")]
    public sealed class TrackAlbum
    {
        /// <summary>
        /// A unique integer based on album identifier
        /// </summary>
        /// <example>2342349</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// Title of album
        /// </summary>
        /// <example>Let There Be Rock</example>
        [DataMember(Order = 2)]
        public string Title { get; set; } = string.Empty;
    }
}
