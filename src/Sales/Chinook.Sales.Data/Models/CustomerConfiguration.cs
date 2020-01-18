using System.Diagnostics.CodeAnalysis;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Sales.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("customer", "sales");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("customer_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fax).HasColumnName("fax");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.State).HasColumnName("state");

            // map support representative (employee) relationship
            entity.Property(e => e.SupportRepresentativeId).HasColumnName("support_rep_id");
            entity.HasOne(e => e.SupportRepresentative).WithMany(e => e!.Customers);
        }
    }
}
