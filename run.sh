#!/usr/bin/env bash

docker-compose -f docker-compose-local.yml up --build -d
cd Habitat.DataAccess
dotnet ef database update