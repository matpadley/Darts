![Build Status](https://github.com/matpadley/Darts/actions/workflows/build_library.yaml/badge.svg)
![Test Status](https://github.com/matpadley/Darts/actions/workflows/test_library.yaml/badge.svg)
![Coverage Status](https://img.shields.io/codecov/c/github/matpadley/Darts)

# DartsScorer

A .NET application for scoring various darts games including X01 (301, 501, etc.), Round the Board, and Killer.

## Project Overview

DartsScorer is designed to help players keep track of scores in different darts game formats. The application consists of a core library for game logic and a web interface for user interaction.

### Features

- Multiple game types:
  - X01 games (301, 501, etc.)
  - Round the Board
  - Killer (in development)
- Player management
- Score tracking and validation
- Checkout suggestions for X01 games

## Project Structure

- **DartsScorer.Main**: Core library with game logic
- **DartsScorer.Web**: ASP.NET Core MVC web application 
- **Tests**: Unit tests for different game components

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Docker (for containerized deployment)

### Running Locally

```sh
# Clone the repository
git clone https://github.com/matpadley/DartsScorer_Proper.git
cd DartsScorer_Proper

# Build and run the web application
dotnet restore
dotnet build
cd DartsScorer.Web
dotnet run
```

### Using Docker

```sh
# Build Docker image
docker build -t dartsscorer-web .

# Run container
docker run -it -p 8080:5000 dartsscorer-web
```

Then access the application at: http://localhost:8080

## Development

### Running Tests

```sh
dotnet test
```

### Project Status

This project is a proof of concept and actively under development. While functional, it is not yet production-ready and may contain bugs or missing features.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
