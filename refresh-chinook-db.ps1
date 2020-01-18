Clear-Host

function Set-ConsoleForegroundColor ($foregroundColor) {
    $currentForegroundColor = $Host.UI.RawUI.ForegroundColor
    $Host.UI.RawUI.ForegroundColor = $foregroundColor
    return $currentForegroundColor
}

$currentForegroundColor = Set-ConsoleForegroundColor "Green"
Write-Host "`r`nScript started! Creating new chinook database using Docker, Docker-Compose, and Postgres."

# Run Postgres in Docker container
Set-ConsoleForegroundColor DarkCyan | Out-Null
Write-Host "`r`nSetup chinook Postgres database in Docker container started"
docker volume create --name pg-chinook-data -d local
docker-compose down
docker-compose up -d
Write-Host "Setup of chinook Postgres database in Docker container complete"

# Drop and recreate any existing Chinook database (postgres client tools required)
Set-ConsoleForegroundColor Yellow | Out-Null
Write-Host "`r`nDrop and recreate any existing chinook database started ..."
docker exec -it pg-chinook dropdb -h localhost -U postgres chinook
docker exec -it pg-chinook createdb -h localhost -U postgres chinook
Write-Host "Drop and recreate any existing chinook database completed ..."

Set-ConsoleForegroundColor Magenta | Out-Null
Write-Host "`r`nRun migrations using Flyway started ..."
$wd = Get-Location
docker run --rm --network chinooknet -v $wd/data/migrations:/flyway/sql boxfuse/flyway:6 -url=jdbc:postgresql://172.22.0.5:5432/chinook -user=postgres -password=password migrate
Write-Host "Run migrations using Flyway completed ..."

# Complete script
Set-ConsoleForegroundColor Green | Out-Null
Write-Host "`r`nScript completed! The chinook database was created successfully!"
Write-Host "Connect to chinook postgres database using the following details (as per 'docker-compose-pg.yml'):"
Write-Host "  - server: localhost (native client) or 172.22.0.5 is using pgAdmin (http://localhost:8080)"
Write-Host "  - username: postgres"
Write-Host "  - password: password`r`n"