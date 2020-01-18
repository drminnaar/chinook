using System.Collections.Generic;
using AutoMapper;
using Chinook.Sales.Domain.Models;

namespace Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models
{
    public sealed class InvoiceMapperProfile : Profile
    {
        public InvoiceMapperProfile()
        {
            CreateMap<Employee, InvoiceCustomerConsultant>();
            CreateMap<Invoice, InvoiceDetail>();
            CreateMap<IPagedCollection<Invoice>, List<InvoiceDetail>>();
        }
    }
}
