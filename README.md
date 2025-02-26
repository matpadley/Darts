![Test Status](https://github.com/matpadley/Darts/actions/workflows/build_library.yaml/badge.svg)

# Darts Scorer

The apps in here are rough and ready proof of concept and by no means production ready. They are missing expection handling.


## Running the Web App

### From a container

```sh
docker build  -t dartsscorer-web .
```

```sh
 docker run -it -p 8080:5000 dartsscorer-web
```
