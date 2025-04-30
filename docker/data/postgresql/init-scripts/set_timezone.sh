set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    ALTER SYSTEM SET timezone = 'Europe/Moscow';
    SELECT pg_reload_conf();
EOSQL