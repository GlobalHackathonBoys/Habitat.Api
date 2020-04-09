# Habitat.Api

API for the Habitat Hackathon Project

## Setup

### Development 

Use the run.sh or run.ps1 script to start the backend and needed services

habitat api -> api.localhost
pgadmin -> pg.localhost

### DB Migrations

#### Setup

~~~~bash
dotnet tool install --global dotnet-ef
~~~~

#### Add New Migration

~~~~bash
cd Habitat.DataAccess
dotnet ef migrations add MigrationName
dotnet ef database update
~~~~

#### Update/Init Database

~~~~bash
cd Habitat.DataAccess
dotnet ef database update
~~~~

More Info: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli