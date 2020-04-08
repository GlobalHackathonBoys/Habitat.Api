docker-compose -f docker-compose-local.yml up --build
cd Habitat.DataAccess
dotnet ef database update