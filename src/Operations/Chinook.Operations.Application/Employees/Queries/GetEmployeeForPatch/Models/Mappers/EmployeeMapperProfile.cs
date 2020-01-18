using AutoMapper;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployee;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployee.Models;
using Chinook.Operations.Domain.Models;

namespace Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch.Models
{
    public sealed class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<EmployeeForUpdate, EmployeeForPatch>();
            CreateMap<Employee, EmployeeForPatch>();
        }
    }
}
