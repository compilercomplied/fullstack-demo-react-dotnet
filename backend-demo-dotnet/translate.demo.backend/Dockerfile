
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
RUN mkdir app
COPY . app
WORKDIR app

RUN dotnet restore
RUN dotnet publish -c Release -o out

# second stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
ARG GOOGLE_PROJECTID=''
ARG GOOGLE_APPLICATION_CREDENTIALS='/fullstack-demo-621.json'

ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT="production"
EXPOSE 5000

RUN mkdir /usr/app
COPY --from=builder app/out .
COPY --from=builder app/fullstack-demo-621.json .

ENTRYPOINT [ "dotnet", "application.api.dll" ]