# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution and project files
COPY . .

WORKDIR /app

# Restore the dependencies
RUN dotnet restore

# Copy the rest of the files
COPY . .

WORKDIR /app

# Build the project
RUN dotnet publish DartsScorer.Web/DartsScorer.Web.csproj -c Release -o out

# Use the official .NET runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out .

# Expose the port
EXPOSE 5000

# Set the environment variable to specify the port
ENV ASPNETCORE_URLS=http://+:5000

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DartsScorer.Web.dll"]