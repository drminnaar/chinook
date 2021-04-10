CREATE TABLE music_catalog.album
(
    "album_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "title" TEXT NOT NULL,
    "artist_id" INT NOT NULL,
    CONSTRAINT "pk_musiccatalog_album_albumid" PRIMARY KEY ("album_id")
);

-- define artist relationship
ALTER TABLE music_catalog.album ADD CONSTRAINT "fk_musiccatalog_album_artistid"
    FOREIGN KEY ("artist_id") REFERENCES music_catalog.artist ("artist_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_musiccatalog_album_artistid" ON music_catalog.album ("artist_id");

-- define indexes
CREATE INDEX "ix_musiccatalog_album_title" ON music_catalog.album ("title");
CREATE INDEX "ix_musiccatalog_album_ltitle" ON music_catalog.album (lower("title"));