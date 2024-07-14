#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
WORKDIR /src/*.csproj ./aspnetapp
RUN dotnet restore --ignore-failed-sources

COPY Tech.Challenge.Grupo27.API/. ./aspnetapp/
WORKDIR /source/aspnetapp

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
WORKDIR /app
COPY --from=build /src/Tech.Challenge.Grupo27.API/out .
ENV ASPNETCORE_URLS=http://+:5000
ENV TZ="America/SAO_Paulo"

ENTRYPOINT ["dotnet", "Tech.Challenge.Grupo27.API.dll"]