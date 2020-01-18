using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> entity)
        {
            entity.ToTable("artist", "music_catalog");
            entity.HasKey(e => e.Id).HasName("pk_artist");
            entity.Property(e => e.Id).HasColumnName("artist_id");
            entity.Property(e => e.Name).HasColumnName("name");
        }
    }
}
