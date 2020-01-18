using AutoMapper;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models
{
    public sealed class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, InvoiceCustomer>()
                .ForMember(destination =>
                    destination.Consultant,
                    options => options.MapFrom(source => source.SupportRepresentative));
        }
    }
}
