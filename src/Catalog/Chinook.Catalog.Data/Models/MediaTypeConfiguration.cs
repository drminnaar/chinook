using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> entity)
        {
            entity.ToTable("media_type", "music_catalog");
            entity.HasKey(e => e.Id).HasName("pk_media_type");
            entity.Property(e => e.Id).HasColumnName("media_type_id");
            entity.Property(e => e.Name).HasColumnName("name");
        }
    }
}
