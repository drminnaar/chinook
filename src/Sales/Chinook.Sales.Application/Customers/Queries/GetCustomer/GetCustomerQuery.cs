using Chinook.Sales.Application.Customers.Queries.GetCustomer.Models;
using MediatR;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer
{
    public sealed class GetCustomerQuery : IRequest<CustomerDetail?>
    {
        public GetCustomerQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}
