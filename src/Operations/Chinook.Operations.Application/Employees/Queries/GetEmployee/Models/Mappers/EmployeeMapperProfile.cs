using System.Collections.Generic;
using AutoMapper;
using Chinook.Operations.Domain.Models;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployee.Models
{
    public sealed class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<Employee, EmployeeDetail>();
            CreateMap<IPagedCollection<Employee>, List<Employee>>();
        }
    }
}
