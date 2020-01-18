using System;
using Chinook.Catalog.Application;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Catalog.Data
{
    public sealed class CatalogDbContext : DbContext, ICatalogDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }
    }
}
