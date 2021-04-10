CREATE TABLE music_catalog.playlist
(
    "playlist_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "name" TEXT NOT NULL,
    CONSTRAINT "pk_musiccatalog_playlist_playlistid" PRIMARY KEY ("playlist_id")
);

-- define indexes
CREATE UNIQUE INDEX "ux_musiccatalog_playlist_name" ON music_catalog.playlist ("name");
CREATE UNIQUE INDEX "ux_musiccatalog_playlist_lname" ON music_catalog.playlist (lower("name"));