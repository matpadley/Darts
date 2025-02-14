# Darts Scorer

## Running the Console App

To run the console app from the command line, navigate to the `DartsScorer.Console` directory and use the following command:

```sh
dotnet run --project DartsScorer.Console.csproj
```

### From a container

```sh
docker build -f Dockerfile.console -t dartsscorer-console .
```

```sh
docker run -it dartsscorer-console
```

## Running the Web App

### From a container

```sh
docker build -f Dockerfile.web -t dartsscorer-web .
```

```sh
 docker run -it -p 8080:5000 dartsscorer-web
```
