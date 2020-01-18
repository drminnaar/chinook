using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> entity)
        {
            entity.ToTable("playlist", "music_catalog");
            entity.HasKey(e => e.Id).HasName("pk_playlist");
            entity.Property(e => e.Id).HasColumnName("playlist_id");
            entity.Property(e => e.Name).HasColumnName("name");

            // map playlist tracks relationship
            entity.HasMany(e => e.PlaylistTracks).WithOne(e => e.Playlist!);
        }
    }
}
