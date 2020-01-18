INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (1, N'Music');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (2, N'Movies');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (3, N'TV Shows');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (4, N'Audiobooks');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (5, N'90�s Music');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (6, N'Audiobooks');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (7, N'Movies');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (8, N'Music');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (9, N'Music Videos');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (10, N'TV Shows');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (11, N'Brazilian Music');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (12, N'Classical');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (13, N'Classical 101 - Deep Cuts');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (14, N'Classical 101 - Next Steps');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (15, N'Classical 101 - The Basics');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (16, N'Grunge');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (17, N'Heavy Metal Classic');
INSERT INTO music_catalog.playlist ("playlist_id", "name") VALUES (18, N'On-The-Go 1');

ALTER TABLE music_catalog.playlist
ALTER COLUMN playlist_id ADD GENERATED ALWAYS AS IDENTITY;

ALTER TABLE music_catalog.playlist ALTER COLUMN playlist_id RESTART WITH 1000;