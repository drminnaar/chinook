CREATE TABLE music_catalog.genre
(
    "genre_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "name" TEXT,
    CONSTRAINT "pk_musiccatalog_genre_genreid" PRIMARY KEY ("genre_id")
);

-- define indexes
CREATE UNIQUE INDEX "ux_musiccatalog_genre_name" ON music_catalog.genre ("name");
CREATE UNIQUE INDEX "ux_musiccatalog_genre_lname" ON music_catalog.genre (lower("name"));