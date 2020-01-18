using System.Diagnostics.CodeAnalysis;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Sales.Data.Models
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Late bound. Used by model builder to apply configurations")]
    internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entity)
        {
            entity.ToTable("invoice", "sales");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("invoice_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.BillingAddress).HasColumnName("billing_address");
            entity.Property(e => e.BillingCity).HasColumnName("billing_city");
            entity.Property(e => e.BillingState).HasColumnName("billing_state");
            entity.Property(e => e.BillingCountry).HasColumnName("billing_country");
            entity.Property(e => e.BillingPostalCode).HasColumnName("billing_postal_code");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.Total).HasColumnName("total");

            // map customer relationship
            entity.HasOne(e => e.Customer).WithMany(e => e.Invoices);
        }
    }
}
