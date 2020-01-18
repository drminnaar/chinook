using System.Threading;
using System.Threading.Tasks;
using Chinook.Operations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Operations.Application
{
    public interface IOperationsDbContext
    {
        DbSet<Employee> Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
