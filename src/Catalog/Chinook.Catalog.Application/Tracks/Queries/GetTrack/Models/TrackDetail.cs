using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models
{
    [DataContract(Name = "Track", Namespace = "http://example.com/chinook")]
    public sealed class TrackDetail
    {
        /// <summary>
        /// A unique integer based track identifier
        /// </summary>
        /// <example>2342349</example>
        [DataMember(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// The name of a track
        /// </summary>
        /// <example>Primal Scream</example>
        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The name of a track
        /// </summary>
        /// <example>Primal Scream</example>
        [DataMember(Order = 3)]
        public string Composer { get; set; } = string.Empty;

        /// <summary>
        /// The price of a track
        /// </summary>
        /// <example>0.99</example>
        [DataMember(Order = 4)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order = 5)]
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Size of track in bytes
        /// </summary>
        /// <example>242525</example>
        [DataMember(Order = 5)]
        public int SizeInBytes { get; set; }

        /// <summary>
        /// The length of track in human friendly form
        /// </summary>
        /// <example>3 minutes</example>
        [DataMember(Order = 6)]
        public string Time { get; set; } = string.Empty;

        /// <summary>
        /// The length of track
        /// </summary>
        /// <example>1800</example>
        [DataMember(Order = 6)]
        public decimal TimeInMilliseconds { get; set; }

        /// <summary>
        /// The genre
        /// </summary>
        /// <example>Rock</example>
        [DataMember(Order = 7)]
        public TrackGenre? Genre { get; set; }

        /// <summary>
        /// The album
        /// </summary>
        /// <example>Razors Edge</example>
        [DataMember(Order = 8)]
        public TrackAlbum? Album { get; set; }

        /// <summary>
        /// The artist
        /// </summary>
        /// <example>Razors Edge</example>
        [DataMember(Order = 9)]
        public TrackArtist? Artist { get; set; }

        /// <summary>
        /// The media type
        /// </summary>
        /// <example>MPEG audio file</example>
        [DataMember(Order = 10)]
        public TrackMediaType? MediaType { get; set; }
    }
}
