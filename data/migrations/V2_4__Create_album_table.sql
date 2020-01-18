CREATE TABLE music_catalog.album
(
    "album_id" INT NOT NULL,
    "title" VARCHAR(160) NOT NULL,
    "artist_id" INT NOT NULL,
    CONSTRAINT "pk_album" PRIMARY KEY  ("album_id")
);

ALTER TABLE music_catalog.album ADD CONSTRAINT "fk_album_artistid"
    FOREIGN KEY ("artist_id") REFERENCES music_catalog.artist ("artist_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_album_artistid" ON music_catalog.album ("artist_id");