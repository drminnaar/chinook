using System.Threading;
using System.Threading.Tasks;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Application
{
    public interface ICatalogDbContext
    {
        DbSet<Track> Tracks { get; }
        DbSet<Playlist> Playlists { get; }
        DbSet<PlaylistTrack> PlaylistTracks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
