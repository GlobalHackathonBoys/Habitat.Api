ARG PROJECT=Habitat.Api

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN   apt-get update \
 &&   apt-get install -y jq
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG PROJECT
WORKDIR /src 
COPY $PROJECT $PROJECT
RUN dotnet restore $PROJECT/$PROJECT.csproj \
&& dotnet restore $PROJECT/$PROJECT.csproj \
&& dotnet build $PROJECT/$PROJECT.csproj -c Release -o /app

FROM build AS publish
ARG PROJECT
RUN dotnet publish $PROJECT/$PROJECT.csproj -c Release -o /app

FROM base as final
ARG PROJECT
ENV PROJECT=$PROJECT
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT dotnet $PROJECT.dll