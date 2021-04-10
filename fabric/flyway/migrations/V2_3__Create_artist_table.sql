CREATE TABLE music_catalog.artist
(
    "artist_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "name" TEXT NOT NULL,
    CONSTRAINT "pk_musiccatalog_artist_artistid" PRIMARY KEY ("artist_id")
);

-- define indexes
CREATE UNIQUE INDEX "ux_musiccatalog_artist_name" ON music_catalog.artist ("name");
CREATE UNIQUE INDEX "ux_musiccatalog_artist_lname" ON music_catalog.artist (lower("name"));