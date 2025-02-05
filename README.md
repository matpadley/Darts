# Darts Scorer

## Project Structure

The project is organized as follows:

- The main project files are located in the `lib/DartsScorer.Main` directory.
- The `lib/DartsScorer.Main` directory contains the main project file `lib/DartsScorer.Main/DartsScorer.Main.csproj`.
- The `lib/DartsScorer.Main/Models` directory contains various model classes and variants.
- The test files are located in the `lib/tests/DartsScorer.Tests` directory.
- The `lib/tests/DartsScorer.Tests` directory contains the test project file `lib/tests/DartsScorer.Tests/DartsScorer.Tests.csproj`.
- The repository contains a `.github` directory with configuration files for GitHub Actions.
- The repository contains a `.gitignore` file for ignoring unnecessary files.

## How to Use the Console Application

### Prerequisites

- Ensure you have [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
- Ensure you have [Docker](https://www.docker.com/get-started) installed if you want to run the application in a Docker container.

### Running the Application Locally

1. Navigate to the `DartsScorer.Console` directory:
    ```sh
    cd DartsScorer.Console
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Run the application:
    ```sh
    dotnet run
    ```

### Running the Application in a Docker Container

1. Build the Docker image:
    ```sh
    docker build -t dartsscorer-console .
    ```

2. Run the Docker container:
    ```sh
    docker run -it dartsscorer-console
    ```

### Using the Application

1. When you run the application, you will be prompted to select a match type.
2. Enter the number corresponding to the match type you want to use.
3. Enter the names of the players when prompted.
4. Follow the on-screen instructions to play the game.

Enjoy scoring your darts game!