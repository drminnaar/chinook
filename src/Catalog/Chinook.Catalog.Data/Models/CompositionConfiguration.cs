using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class CompositionConfiguration : IEntityTypeConfiguration<Composition>
    {
        public void Configure(EntityTypeBuilder<Composition> entity)
        {
            entity.ToTable("composition", "music_catalog");
            entity.HasKey(e => new { e.PlaylistId, e.TrackId }).HasName("pk_composition");

            // map track relationship
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.HasOne(e => e.Track).WithMany(e => e!.Compositions);

            // map track relationship
            entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");
            entity.HasOne(e => e.Playlist).WithMany(e => e!.PlaylistTracks);
        }
    }
}
