# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution and project files
COPY lib/ lib/
COPY DartsScorer.Console/ DartsScorer.Console/

WORKDIR /app/lib

# Restore the dependencies
RUN dotnet restore

# Copy the rest of the files
COPY . .

WORKDIR /app

# Build the project
RUN dotnet publish DartsScorer.Console/DartsScorer.Console.csproj -c Release -o out

# Use the official .NET runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DartsScorer.Console.dll"]