using System;
using System.Threading.Tasks;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models;
using Chinook.Catalog.Application.Tracks.Commands.CreateTrack;
using Chinook.Catalog.Application.Tracks.Commands.CreateTrack.Models;
using Chinook.Catalog.Application.Tracks.Commands.DeleteTrack;
using Chinook.Catalog.Application.Tracks.Commands.UpdateTrack;
using Chinook.Catalog.Application.Tracks.Commands.UpdateTrack.Models;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Chinook.Catalog.Api.Controllers
{
    [ApiController]
    [Route("v1/tracks")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public sealed class TracksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlHelper _urlHelper;

        public TracksController(IMediator mediator, IUrlHelper urlHelper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        /// <summary>
        /// Get a single track based on specified track id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tracks/35345
        ///
        /// </remarks>
        /// <param name="trackId">The track id</param>
        /// <returns>Returns a single track based on specified track id</returns>
        /// <response code="200">Returns a single track based on specified track id</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">A track could not be found for specified track id</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet("{trackId:int}", Name = nameof(GetTrackById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTrackById(int trackId)
        {
            var track = await _mediator.Send(new GetTrackQuery(trackId));

            if (track == null)
                return NotFound();

            return Ok(track);
        }

        /// <summary>
        /// Get list of playlists by track id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tracks/35345/playlists
        ///
        /// </remarks>
        /// <param name="trackId">The track id</param>
        /// <param name="playlistQuery"></param>
        /// <returns>Returns a single track based on specified track id</returns>
        /// <response code="200">Returns a single track based on specified track id</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">A track could not be found for specified track id</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet("{trackId:int}/playlists", Name = nameof(GetPlaylistsTrackById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Playlists" })]
        public async Task<IActionResult> GetPlaylistsTrackById(
            [FromRoute]int trackId,
            [FromQuery]PlaylistQuery playlistQuery)
        {
            var track = await _mediator.Send(new GetPlaylistListQuery(trackId, playlistQuery));

            if (track == null)
                return NotFound();

            return Ok(track);
        }

        /// <summary>
        /// Get a list of tracks
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tracks?page=1
        ///
        /// </remarks>
        /// <param name="trackQuery"></param>
        /// <returns>Returns a collection of tracks with pagination details in the 'x-pagination' header</returns>
        /// <response code="200">Returns a collection of tracks with pagination details in the 'x-pagination' header</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet(Name = nameof(GetTracks))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTracks([FromQuery]TrackQuery trackQuery)
        {
            var response = await _mediator.Send(new GetTrackListQuery(trackQuery));

            return this.OkWithPageHeader(response, nameof(GetTracks), trackQuery, _urlHelper);
        }

        /// <summary>
        /// Create a new track
        /// </summary>
        /// <param name="track"></param>
        /// <returns>New track</returns>
        /// <response code="201">Returns new track</response>
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
        public async Task<IActionResult> CreateTrack([FromBody]TrackForCreate track)
        {
            var trackFromCreate = await _mediator.Send(new CreateTrackCommand(track));

            if (trackFromCreate == null)
                throw new InvalidOperationException("Expected a non-null track from track creation");

            return CreatedAtAction(nameof(GetTrackById), new { trackId = trackFromCreate.Id }, trackFromCreate);
        }

        /// <summary>
        /// Delete track by track id
        /// </summary>
        /// <param name="trackId">Track id</param>
        /// <returns>No content</returns>
        /// <response code="204">No content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">A track could not be found for specified track id</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpDelete("{trackId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrack(int trackId)
        {
            await _mediator.Send(new DeleteTrackCommand(trackId));

            return NoContent();
        }

        /// <summary>
        /// Returns metadata in the header of the response that describes what other methods
        /// and operations are supported at this URL
        /// </summary>
        /// <returns>Supported methods in header of response</returns>
        [HttpOptions]
        public IActionResult GetTracksOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,DELETE");

            return Ok();
        }

        /// <summary>
        /// Update track having specified track id
        /// </summary>
        /// <param name="trackId">Unique track identifier</param>
        /// <param name="track">Track data for update</param>
        /// <returns></returns>
        /// <response code="204">No content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">A track could not be found for specified track id</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPut("{trackId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTrack(int trackId, [FromBody]TrackForUpdate track)
        {
            await _mediator.Send(new UpdateTrackCommand(trackId, track));

            return NoContent();
        }
    }
}
