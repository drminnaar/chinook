using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity.ToTable("album", "music_catalog");
            entity.HasKey(e => e.Id).HasName("pk_album");
            entity.Property(e => e.Id).HasColumnName("album_id");
            entity.Property(e => e.Title).HasColumnName("title");

            // map artist relationship
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.HasOne(e => e.Artist);
        }
    }
}
