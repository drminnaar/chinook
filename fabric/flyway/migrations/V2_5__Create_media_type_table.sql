CREATE TABLE music_catalog.media_type
(
    "media_type_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "name" TEXT NOT NULL,
    CONSTRAINT "pk_musiccatalog_mediatype_mediatypeid" PRIMARY KEY  ("media_type_id")
);

-- define indexes
CREATE UNIQUE INDEX "ux_musiccatalog_mediatype_name" ON music_catalog.media_type ("name");
CREATE UNIQUE INDEX "ux_musiccatalog_mediatype_lname" ON music_catalog.media_type (lower("name"));