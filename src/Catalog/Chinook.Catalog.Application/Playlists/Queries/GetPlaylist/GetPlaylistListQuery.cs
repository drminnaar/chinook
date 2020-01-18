using System.Collections.Generic;
using Chinook.Catalog.Application.Playlists.Queries.GetPlaylist.Models;
using MediatR;

namespace Chinook.Catalog.Application.Playlists.Queries.GetPlaylist
{
    public sealed class GetPlaylistListQuery : IRequest<IPagedCollection<PlaylistDetail>>
    {
        public GetPlaylistListQuery(int trackId, PlaylistQuery playlistQuery) : this(playlistQuery)
        {
            TrackId = trackId;
        }

        public GetPlaylistListQuery(PlaylistQuery playlistQueryParams)
        {
            if (playlistQueryParams is null)
                throw new System.ArgumentNullException(nameof(playlistQueryParams));

            Name = playlistQueryParams.Name;
            Order = playlistQueryParams.Order;
            PageNumber = playlistQueryParams.PageNumber;
            PageSize = playlistQueryParams.PageSize;
        }

        public string? Name { get; }
        public string? Order { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int? TrackId { get; }
    }
}
