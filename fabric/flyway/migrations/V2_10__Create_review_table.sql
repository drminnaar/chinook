CREATE TABLE music_catalog.review
(
    "review_id" BIGINT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "account_id" UUID NOT NULL,
    "playlist_id" INT NOT NULL,
    "rating" NUMERIC (2,1) NOT NULL,
    CONSTRAINT "pk_musiccatalog_review_reviewid" PRIMARY KEY ("review_id")
);

-- define playlist relationship
ALTER TABLE music_catalog.review ADD CONSTRAINT "fk_musiccatalog_review_playlistid"
    FOREIGN KEY ("playlist_id") REFERENCES music_catalog.playlist ("playlist_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_musiccatalog_review_playlistid" ON music_catalog.review ("playlist_id");

-- create unique index on account and playlist
CREATE UNIQUE INDEX "ux_musiccatalog_review_accountid_playlistid" ON music_catalog.review ("account_id", "playlist_id");