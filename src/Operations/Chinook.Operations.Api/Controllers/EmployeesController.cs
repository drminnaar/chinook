using System;
using System.Threading.Tasks;
using AutoMapper;
using Chinook.Operations.Application.Employees.Commands.CreateEmployee;
using Chinook.Operations.Application.Employees.Commands.CreateEmployee.Models;
using Chinook.Operations.Application.Employees.Commands.DeleteEmployee;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployee;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployee.Models;
using Chinook.Operations.Application.Employees.Commands.UpdateEmployeeAddress;
using Chinook.Operations.Application.Employees.Queries.GetEmployee;
using Chinook.Operations.Application.Employees.Queries.GetEmployee.Models;
using Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch;
using Chinook.Operations.Application.Employees.Queries.GetEmployeeForPatch.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Operations.Api.Controllers
{
    [ApiController]
    [Route("v1/employees")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public sealed class EmployeesController : ControllerBase
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeesController(IUrlHelper urlHelper, IMediator mediator, IMapper mapper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Delete an employee by employee id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>No content</returns>
        /// <response code="204">No content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpDelete("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee([FromRoute]int employeeId)
        {
            await _mediator.Send(new DeleteEmployeeCommand(employeeId));
            return NoContent();
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>New employee</returns>
        /// <response code="201">Returns new employee</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeForCreate employee)
        {
            var employeeFromCreate = await _mediator.Send(new CreateEmployeeCommand(employee));

            if (employeeFromCreate == null)
                throw new InvalidOperationException("Expected a non-null employee from employee creation");

            return CreatedAtAction(nameof(GetEmployee), new { employeeId = employeeFromCreate.Id }, employeeFromCreate);
        }

        /// <summary>
        /// Get single employee by employee identifier
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /employees/1234
        ///
        /// </remarks>
        /// <returns>Returns a single employee based on specified employee id</returns>
        /// <response code="200">Returns a single employee based on specified employee id</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">An employee having specified employee id does not exist</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet("{employeeId:int}", Name = nameof(GetEmployee))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            var employee = await _mediator.Send(new GetEmployeeQuery(employeeId));

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Get a list of employees
        /// </summary>
        /// <remarks>
        /// Sample requests:
        ///
        ///     GET /employees?last-name=johnson&#x26;order=-last-name,first-name
        ///     GET /employees?page=1&#x26;limit=20&#x26;from-birthdate=gte:1970-06-30&#x26;order=-from-birthdate
        ///
        /// </remarks>
        /// <returns>Returns a collection of invoices with pagination details in the 'x-pagination' header</returns>
        /// <response code="200">Returns a collection of invoices with pagination details in the 'x-pagination' header</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet(Name = nameof(GetEmployees))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployees([FromQuery]EmployeeQuery employeeQuery)
        {
            var response = await _mediator.Send(new GetEmployeeListQuery(employeeQuery));
            return this.OkWithPageHeader(response, nameof(GetEmployees), employeeQuery, _urlHelper);
        }

        /// <summary>
        /// Update employee address
        /// </summary>
        /// <param name="employeeId">Unique employee identifier</param>
        /// <param name="address">Address changes</param>
        /// <returns>No content</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPut("{employeeId:int}/address")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployeeAddress(
            [FromRoute]int employeeId,
            [FromBody]EmployeeAddressForUpdate address)
        {
            await _mediator.Send(new UpdateEmployeeAddressCommand(employeeId, address));
            return NoContent();
        }

        /// <summary>
        /// Do partial employee updates
        /// </summary>
        /// <param name="employeeId">Unique employee identifier</param>
        /// <param name="employeePatch">Address changes</param>
        /// <returns>No content</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPatch("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEmployee(
            [FromRoute]int employeeId,
            [FromBody]JsonPatchDocument<EmployeeForPatch> employeePatch)
        {
            var employeeForPatch = await _mediator.Send(new GetEmployeeForPatchQuery(employeeId));

            if (employeeForPatch == null)
                return NotFound();

            employeePatch.ApplyTo(employeeForPatch, ModelState);

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            await _mediator.Send(new UpdateEmployeeCommand(
                employeeId,
                new EmployeeForUpdate
                {
                    Address = employeeForPatch.Address,
                    BirthDate = employeeForPatch.BirthDate,
                    City = employeeForPatch.City,
                    Country = employeeForPatch.Country,
                    Email = employeeForPatch.Email,
                    Fax = employeeForPatch.Fax,
                    FirstName = employeeForPatch.FirstName,
                    HireDate = employeeForPatch.HireDate,
                    LastName = employeeForPatch.LastName,
                    ManagerId = employeeForPatch.ManagerId,
                    Phone = employeeForPatch.Phone,
                    PostalCode = employeeForPatch.PostalCode,
                    State = employeeForPatch.State,
                    Title = employeeForPatch.Title
                }));

            return NoContent();
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeId">Unique employee identifier</param>
        /// <param name="employeeUpdate"></param>
        /// <returns>No content</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPut("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployee(
            [FromRoute]int employeeId,
            [FromBody]EmployeeForUpdate employeeUpdate)
        {
            await _mediator.Send(new UpdateEmployeeCommand(employeeId, employeeUpdate));
            return NoContent();
        }
    }
}
