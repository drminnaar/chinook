CREATE SCHEMA music_catalog;

-- configure 'admin' role access
GRANT ALL PRIVILEGES ON SCHEMA music_catalog TO admin;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA music_catalog TO admin;
ALTER DEFAULT PRIVILEGES IN SCHEMA music_catalog GRANT ALL PRIVILEGES ON TABLES TO admin;

-- configure 'readonly' role access
GRANT USAGE ON SCHEMA music_catalog TO readonly;
GRANT SELECT ON ALL TABLES IN SCHEMA music_catalog TO readonly;
ALTER DEFAULT PRIVILEGES IN SCHEMA music_catalog GRANT SELECT ON TABLES TO readonly;

-- configure 'readwrite' role access
GRANT USAGE, CREATE ON SCHEMA music_catalog TO readwrite;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA music_catalog TO readwrite;
ALTER DEFAULT PRIVILEGES IN SCHEMA music_catalog GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO readwrite;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA music_catalog TO readwrite;
ALTER DEFAULT PRIVILEGES IN SCHEMA music_catalog GRANT USAGE ON SEQUENCES TO readwrite;