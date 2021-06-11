# Project description

Small dotnet project showcasing a simple translation api. Dockerfile triggers production-ready build.

You can either run with a mock translation provider implementation that simply returns the string reversed (with the language code appended) or create a google cloud project and use the credentials and resources you can create following [google's own documentation](https://cloud.google.com/docs/authentication/getting-started).

`docker build . -t backend`
`docker run -p 5000:5000 backend`

In case you want to opt-in into google APIs you can use the following command to run the image.

`docker run -p 5000:5000 -e GOOGLE_PROJECTID='fullstack-demo-PROJECTID' -e GOOGLE_APPLICATION_CREDENTIALS='C:\fullstack-demo.json' backend`

You'll need to copy the credentials to the container filesystem, i.e:

`docker cp C:\fullstack-demo.json $BACKEN_CONTAINER:/fullstack-demo.json`
