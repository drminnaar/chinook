CREATE TABLE music_catalog.playlist
(
    "playlist_id" INT NOT NULL,
    "name" VARCHAR(120),
    CONSTRAINT "pk_playlist" PRIMARY KEY  ("playlist_id")
);