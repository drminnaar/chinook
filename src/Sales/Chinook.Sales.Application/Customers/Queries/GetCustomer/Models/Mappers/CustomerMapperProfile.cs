using AutoMapper;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Customers.Queries.GetCustomer.Models
{
    public sealed class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerDetail>()
                .ForMember(destination =>
                    destination.Consultant,
                    options => options.MapFrom(source => source.SupportRepresentative));
        }
    }
}
