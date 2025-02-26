![Test Status](https://github.com/matpadley/Darts/actions/workflows/build_library.yaml/badge.svg)

# Darts Scorer

The apps in here are rough and ready proof of concept and by no means production ready. They are missing expection handling.

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
