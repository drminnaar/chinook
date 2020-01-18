using System;
using System.Threading.Tasks;
using Chinook.Sales.Application.Customers.Queries.GetCustomer;
using Chinook.Sales.Application.Customers.Queries.GetCustomer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Sales.Api.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public sealed class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlHelper _urlHelper;

        public CustomersController(IMediator mediator, IUrlHelper urlHelper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        /// <summary>
        /// Get single customer by customer identifier
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /customers/1234
        ///
        /// </remarks>
        /// <returns>Returns a single customers based on specified customer id</returns>
        /// <response code="200">Returns a single customer based on specified customer id</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">The resource could not be found</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet("{customerId:int}", Name = nameof(GetCustomerByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> GetCustomerByIdAsync(int customerId)
        {
            if (customerId < 1)
            {
                ModelState.AddModelError(nameof(customerId), "Expected non-negative value greater than zero");
                return Task.FromResult<IActionResult>(UnprocessableEntity(ModelState));
            }

            async Task<IActionResult> GetCustomerByIdAsync()
            {
                var customer = await _mediator.Send(new GetCustomerQuery(customerId));

                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }

            return GetCustomerByIdAsync();
        }

        /// <summary>
        /// Get a list of customers
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /customers?page=1
        ///
        /// </remarks>
        /// <returns>Returns a collection of customers with pagination details in the 'x-pagination' header</returns>
        /// <response code="200">Returns a collection of customers with pagination details in the 'x-pagination' header</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet(Name = nameof(GetCustomersAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> GetCustomersAsync([FromQuery]CustomerQuery customerQuery)
        {
            if (customerQuery is null)
                throw new ArgumentNullException(nameof(customerQuery));

            async Task<IActionResult> GetCustomersAsync()
            {
                var customers = await _mediator.Send(new GetCustomerListQuery(customerQuery));
                return this.OkWithPageHeader(customers, nameof(GetCustomersAsync), customerQuery, _urlHelper);
            }

            return GetCustomersAsync();
        }
    }
}
