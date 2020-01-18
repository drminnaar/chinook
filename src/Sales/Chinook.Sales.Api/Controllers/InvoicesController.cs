using System;
using System.Threading.Tasks;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice;
using Chinook.Sales.Application.Invoices.Queries.GetInvoice.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Sales.Api.Controllers
{
    [ApiController]
    [Route("v1/invoices")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public sealed class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlHelper _urlHelper;

        public InvoicesController(IMediator mediator, IUrlHelper urlHelper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        /// <summary>
        /// Get single invoice by invoice identifier
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /invoices/1234
        ///
        /// </remarks>
        /// <returns>Returns a single invoice based on specified invoice id</returns>
        /// <response code="200">Returns a single invoice based on specified invoice id</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">Resource not found</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet("{invoiceId:int}", Name = nameof(GetInvoiceByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> GetInvoiceByIdAsync(int invoiceId)
        {
            if (invoiceId < 1)
            {
                ModelState.AddModelError(nameof(invoiceId), "Expected value greater than zero");
                return Task.FromResult<IActionResult>(UnprocessableEntity(ModelState));
            }

            async Task<IActionResult> GetInvoicesAsync()
            {
                var invoice = await _mediator.Send(new GetInvoiceQuery(invoiceId));

                if (invoice == null)
                    return NotFound();

                return Ok(invoice);
            }

            return GetInvoicesAsync();
        }

        /// <summary>
        /// Get a list of invoices
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /invoices?page=1
        ///
        /// </remarks>
        /// <returns>Returns a collection of invoices with pagination details in the 'x-pagination' header</returns>
        /// <response code="200">Returns a collection of invoices with pagination details in the 'x-pagination' header</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet(Name = nameof(GetInvoicesAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> GetInvoicesAsync([FromQuery]InvoiceQuery invoiceQuery)
        {
            if (invoiceQuery is null)
                throw new ArgumentNullException(nameof(invoiceQuery));

            async Task<IActionResult> GetInvoicesAsync()
            {
                var invoices = await _mediator.Send(new GetInvoiceListQuery(invoiceQuery));
                return this.OkWithPageHeader(invoices, nameof(GetInvoicesAsync), invoiceQuery, _urlHelper);
            }

            return GetInvoicesAsync();
        }
    }
}
