#! /bin/bash

clear

YELLOW='\033[0;33m'
LIGHT_YELLOW='\033[0;93m'
GREEN='\033[0;32m'
CYAN='\033[0;36m'
MAGENTA='\033[0;35m'
LIGHT_MAGENTA='\033[0;95m'
NC='\033[0m' # No Color

echo -e "\r\n${GREEN}Script started! Creating new chinook database using Docker, Docker-Compose, and Postgres."

# Run Postgres in Docker container
echo -e "\r\n${CYAN}Setup chinook Postgres database in Docker container started${NC}"
docker volume create --name pg-chinook-data -d local
docker-compose down
docker-compose up -d
echo -e "${CYAN}Setup of chinook Postgres database in Docker container complete"

# Drop and recreate any existing Chinook database (postgres client tools required)
echo -e "\r\n${LIGHT_YELLOW}Drop and recreate any existing chinook database started ...${NC}"
docker exec -it pg-chinook dropdb -h localhost -U postgres chinook
docker exec -it pg-chinook createdb -h localhost -U postgres chinook
echo -e "${LIGHT_YELLOW}Drop and recreate any existing chinook database completed ...${NC}"

echo -e "\r\n${LIGHT_MAGENTA}Run migrations using Flyway started ...${MAGENTA}"
docker run --rm --network chinooknet -v $PWD/data/migrations:/flyway/sql boxfuse/flyway:6 -url=jdbc:postgresql://172.22.0.5:5432/chinook -user=postgres -password=password migrate
echo -e "${LIGHT_MAGENTA}Run migrations using Flyway completed ..."

# Complete script
echo -e "\r\n${GREEN}Script completed! The chinook database was created successfully!"
echo -e "Connect to chinook postgres database using the following details (as per 'docker-compose-pg.yml'):"
echo -e "  - server: localhost (native client) or 172.22.0.5 is using pgAdmin (http://localhost:8080)"
echo -e "  - username: postgres"
echo -e "  - password: password\r\n${NC}"