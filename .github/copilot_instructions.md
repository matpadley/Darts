# Copilot Instructions for DartsScorer Solution

## Overview
This solution is built using the following technologies:
- **C#** as the primary programming language.
- **ASP.NET Core** for the web application.
- **NUnit** for unit testing.
- **Moq** for mocking dependencies in tests.
- **Docker** for containerization.

## Testing Guidelines
- All unit tests should be written using **NUnit**.
- Avoid using **xUnit** for new tests as the solution has migrated to **NUnit**.
- Use **Moq** to mock dependencies in unit tests.
- Ensure that tests are placed in the appropriate `tests/` folder corresponding to the project being tested.

## Folder Structure
- **DartsScorer.Web**: Contains the web application code, including controllers, models, and views.
- **DartsScorer.Main**: Contains the core logic for scoring, players, and matches.
- **tests/**: Contains unit tests for various components of the solution.

## Running Tests
To run the tests, use the following command:
```bash
# Run all tests
dotnet test
```
Ensure that all tests pass before committing changes.

## Contribution Guidelines
- Follow the existing coding conventions in the solution.
- Write unit tests for any new functionality.
- Update documentation if changes affect the existing behavior.

## Notes
- The solution uses **Docker** for containerization. Refer to the `Dockerfile` and `docker-compose.yml` for details.
- Configuration files for the web application are located in the `DartsScorer.Web` folder.

## Contact
For any questions or issues, please contact the project maintainer.