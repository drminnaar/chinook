namespace Chinook.Catalog.Domain.Models
{
    public sealed class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
