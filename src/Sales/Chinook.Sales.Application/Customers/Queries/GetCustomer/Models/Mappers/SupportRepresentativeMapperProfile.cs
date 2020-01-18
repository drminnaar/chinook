using AutoMapper;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    public sealed class SupportRepresentativeMapperProfile : Profile
    {
        public SupportRepresentativeMapperProfile()
        {
            CreateMap<Employee, CustomerConsultant>();
        }
    }
}
