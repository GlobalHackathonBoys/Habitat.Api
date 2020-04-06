# Habitat.Api

API for the Habitat Hackathon Project

## Setup

### Development 

docker-compose -f docker-compose-local.yml up --build

habitat api -> api.localhost
pgadmin -> pg.localhost

### DB Migrations

#### Setup

dotnet tool install --global dotnet-ef

#### Add New Migration

cd Habitat.DataAccess
dotnet ef migrations add MigrationName
dotnet ef database update

#### Update/Init Database

cd Habitat.DataAccess
dotnet ef database update

More Info: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli