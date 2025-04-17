# GitHub Copilot Instructions - DartsScorer Project

## Project Overview

DartsScorer is a .NET application designed to help users keep track of scores in various darts games. The application supports multiple dart game types including X01 (301, 501, etc.), Round the Board, and Killer. This is a proof-of-concept project that demonstrates scoring functionality for dart games.

## Project Structure

- **DartsScorer.Main**: Core library containing game logic, player management, and scoring calculations
  - `Checkout`: Contains checkout pattern calculations for X01 games
  - `Match`: Game type implementations (X01, Round the Board, Killer)
  - `Player`: Player management and team functionality
  - `Scoring`: Core scoring logic and dart board representation

- **DartsScorer.Web**: ASP.NET Core MVC web application
  - `Controllers`: Web controllers for different game types and player management
  - `Services`: Backend services that interface with the core library
  - `Views`: Web views for user interaction
  - `Middleware`: Error handling and request processing

- **Tests**: Multiple test projects for different components

## Development Guidelines

1. **Game Logic**:
   - Maintain separation between game types (X01, Round the Board, Killer)
   - Keep scoring logic in the appropriate `Match` subdirectory
   - Checkout patterns for X01 are pre-computed in `CheckoutData.cs`

2. **Web Application**:
   - Follow MVC pattern with controllers handling route requests
   - Use services to interact with the core library
   - Maintain validation for player names and score inputs

3. **Code Style**:
   - Use C# naming conventions (PascalCase for public members)
   - Add XML documentation comments for public classes and methods
   - Use nullable reference types where appropriate

4. **Error Handling**:
   - Use custom exceptions from `DartsScorerExceptions.cs`
   - Add appropriate logging with severity levels
   - Sanitize user inputs to prevent injection attacks

5. **Testing**:
   - Write unit tests for new functionality
   - Ensure tests cover edge cases in scoring logic
   - Organize tests by game type and functionality

## Common Tasks

### Adding a New Game Type

1. Create a new subdirectory in `DartsScorer.Main/Match`
2. Implement game-specific player and match classes
3. Add appropriate services in the web application
4. Create controllers and views for the new game type

### Modifying Checkout Patterns

The `CheckoutData.cs` file contains pre-computed optimal checkout patterns for X01 games. When modifying:
1. Ensure patterns follow the darts rules (finish on a double)
2. Update the test cases in `DartsScorer.Checkout/CheckoutTests.cs`

### Adding Player Functionality

1. Extend the base `Player` class or `MatchPlayer` class in `DartsScorer.Main/Player`
2. Update the `PlayerService` in the web application
3. Modify the player views as needed

## Running the Application

The application can be run locally or via Docker:

```sh
# Build Docker image
docker build -t dartsscorer-web .

# Run container
docker run -it -p 8080:5000 dartsscorer-web
```

## Testing

Run tests using the .NET test runner:

```sh
dotnet test
```