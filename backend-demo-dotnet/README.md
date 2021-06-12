# Project description

Small dotnet project showcasing a simple translation api. Dockerfile triggers production-ready build.

You can either run with a mock translation provider implementation that simply returns the string reversed (with the language code appended) or create a google cloud project and use the credentials and resources you can create following [google's own documentation](https://cloud.google.com/docs/authentication/getting-started).

```Shell
docker build . -t backend
docker run -p 5000:5000 backend
```

In case you want to opt-in into google APIs, you should put your google credentials content inside the `fullstack-demo-621.json` located at the project's root. After that, you can use the following command to run the image:

```Shell
docker run -p 5000:5000 -e GOOGLE_PROJECTID='fullstack-demo-621-lw' -e GOOGLE_APPLICATION_CREDENTIALS='/fullstack-demo-621.json' backend
```

Where the *fullstack_demo_PROJECTID* value is the one you get from your own google project.