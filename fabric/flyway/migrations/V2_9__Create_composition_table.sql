CREATE TABLE music_catalog.composition
(
    "playlist_id" INT NOT NULL,
    "track_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    CONSTRAINT "pk_musiccatalog_composition_playlistid_trackid" PRIMARY KEY ("playlist_id", "track_id")
);

-- define playlist relationship
ALTER TABLE music_catalog.composition ADD CONSTRAINT "fk_musiccatalog_composition_playlistid"
    FOREIGN KEY ("playlist_id") REFERENCES music_catalog.playlist ("playlist_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_musiccatalog_composition_playlistid" ON music_catalog.composition ("playlist_id");

-- define track relationship
ALTER TABLE music_catalog.composition ADD CONSTRAINT "fk_musiccatalog_composition_trackid"
    FOREIGN KEY ("track_id") REFERENCES music_catalog.track ("track_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_musiccatalog_composition_trackid" ON music_catalog.composition ("track_id");