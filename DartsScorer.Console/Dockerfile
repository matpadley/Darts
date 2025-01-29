# add as a base image to .net core sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# COPY the project files to the container
COPY . .

# COPY the lib files to the container
COPY ../lib/DartsScorer.Main lib/DartsScorer.Main

