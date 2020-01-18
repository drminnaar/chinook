using System.Runtime.Serialization;

namespace Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models
{
    [DataContract(Name = "Track", Namespace = "http://example.com/chinook")]
    public sealed class TrackFromCreate
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string Composer { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public decimal Price { get; set; }

        [DataMember(Order = 5)]
        public int Bytes { get; set; }

        [DataMember(Order = 6)]
        public int Milliseconds { get; set; }

        [DataMember(Order = 7)]
        public int AlbumId { get; set; }

        [DataMember(Order = 8)]
        public int GenreId { get; set; }

        [DataMember(Order = 9)]
        public int MediaTypeId { get; set; }
    }
}
