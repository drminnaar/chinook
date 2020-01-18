using System;
using Chinook.Operations.Application;
using Chinook.Operations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Data
{
    public sealed class OperationsDbContext : DbContext, IOperationsDbContext
    {
        public OperationsDbContext(DbContextOptions<OperationsDbContext> options) : base(options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperationsDbContext).Assembly);
        }
    }
}
