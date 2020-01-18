CREATE TABLE music_catalog.playlist_track
(
    "playlist_id" INT NOT NULL,
    "track_id" INT NOT NULL,
    CONSTRAINT "pk_playlist_track" PRIMARY KEY  ("playlist_id", "track_id")
);

ALTER TABLE music_catalog.playlist_track ADD CONSTRAINT "fk_playlisttrack_playlistid"
    FOREIGN KEY ("playlist_id") REFERENCES music_catalog.playlist ("playlist_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE music_catalog.playlist_track ADD CONSTRAINT "fk_playlisttrack_trackid"
    FOREIGN KEY ("track_id") REFERENCES music_catalog.track ("track_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_playlisttrack_trackid" ON music_catalog.playlist_track ("track_id");