using System.Threading;
using System.Threading.Tasks;
using Chinook.Sales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Sales.Application
{
    public interface ISalesDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Invoice> Invoices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
