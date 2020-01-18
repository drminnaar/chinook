using System.Diagnostics.CodeAnalysis;
using Chinook.Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Catalog.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class PlaylistTrackConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> entity)
        {
            entity.ToTable("playlist_track", "music_catalog");
            entity.HasKey(e => new { e.PlaylistId, e.TrackId }).HasName("pk_playlist_track");

            // map track relationship
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.HasOne(e => e.Track).WithMany(e => e!.PlaylistTracks);

            // map track relationship
            entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");
            entity.HasOne(e => e.Playlist).WithMany(e => e!.PlaylistTracks);
        }
    }
}
