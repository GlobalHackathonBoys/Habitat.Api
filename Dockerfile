ARG PROJECT=Habitat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN   apt-get update \
 &&   apt-get install -y jq
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG PROJECT
WORKDIR /src 
COPY $PROJECT.Api $PROJECT.Api
COPY $PROJECT.Application $PROJECT.Application
COPY $PROJECT.Common $PROJECT.Common
COPY $PROJECT.DataAccess $PROJECT.DataAccess
COPY $PROJECT.Domain $PROJECT.Domain

RUN dotnet restore $PROJECT.Api/$PROJECT.Api.csproj \
&& dotnet restore $PROJECT.Api/$PROJECT.Api.csproj \
&& dotnet build $PROJECT.Api/$PROJECT.Api.csproj -c Release -o /app

FROM build AS publish
ARG PROJECT
RUN dotnet publish $PROJECT.Api/$PROJECT.Api.csproj -c Release -o /app

FROM base as final
ARG PROJECT
ENV PROJECT=$PROJECT.Api
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT dotnet $PROJECT.dll