using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Catalog.Application.Playlists.Commands.DeleteTracksFromPlaylist;
using Chinook.Catalog.Application.Playlists.CommandsAddTracksToPlaylist;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack;
using Chinook.Catalog.Application.Tracks.Queries.GetTrack.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Swashbuckle.AspNetCore.Annotations;

namespace Chinook.Catalog.Api.Controllers
{
    [ApiController]
    [Route("v1/playlists/{playlistId:int}/tracks")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class PlaylistTracksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlHelper _urlHelper;

        public PlaylistTracksController(IMediator mediator, IUrlHelper urlHelper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        /// <summary>
        /// Add a list of tracks to an existing playlist
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /playlists/{playlistId:int}/tracks/1,2,3,4
        ///
        /// </remarks>
        /// <param name="playlistId">Playlist identifier</param>
        /// <param name="trackIds">A list of comma separated track id's</param>
        /// <returns>No content</returns>
        /// <response code="204">No content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">Resource could not be found for specified playlist id</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpPut("{trackIds}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Playlists" })]
        public async Task<IActionResult> AddTracksToPlaylist(
            [FromRoute]int playlistId,
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]IReadOnlyCollection<int> trackIds)
        {
            await _mediator.Send(new AddTracksToPlaylistCommand(playlistId, trackIds));

            return NoContent();
        }

        /// <summary>
        /// Delete a list of tracks from an existing playlist
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /playlists/{playlistId:int}/tracks/1,2,3,4
        ///
        /// </remarks>
        /// <param name="playlistId">Playlist identifier</param>
        /// <param name="trackIds">A list of comma separated track id's</param>
        /// <returns>No content</returns>
        /// <response code="204">No content</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="404">Resource could not be found for specified playlist id and track ids</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="500">A server fault occurred</response>
        [HttpDelete("{trackIds}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Playlists" })]
        public async Task<IActionResult> DeleteTracksFromPlaylist(
            [FromRoute]int playlistId,
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]IReadOnlyCollection<int> trackIds)
        {
            await _mediator.Send(new DeleteTracksFromPlaylistCommand(playlistId, trackIds));

            return NoContent();
        }

        /// <summary>
        /// Get list of tracks by playlist id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /playlists/{playlistId:int}/tracks
        ///
        /// </remarks>
        /// <param name="playlistId">Playlist identifier</param>
        /// <param name="trackQuery"></param>
        /// <returns>Returns a collection of tracks with pagination details in the 'x-pagination' header</returns>
        /// <response code="200">Returns a collection of tracks with pagination details in the 'x-pagination' header</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications</response>
        /// <response code="406">When a request is specified in an unsupported content type using the Accept header</response>
        /// <response code="415">When a response is specified in an unsupported content type</response>
        /// <response code="422">If query params structure is valid, but the values fail validation</response>
        /// <response code="500">A server fault occurred</response>
        [HttpGet(Name = nameof(GetTracksByPlaylistId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Tracks" })]
        public async Task<IActionResult> GetTracksByPlaylistId(
            [FromRoute]int playlistId,
            [FromQuery]TrackQuery trackQuery)
        {
            var tracks = await _mediator.Send(new GetTrackListQuery(playlistId, trackQuery));

            return this.OkWithPageHeader(tracks, nameof(GetTracksByPlaylistId), trackQuery, _urlHelper);
        }
    }
}
