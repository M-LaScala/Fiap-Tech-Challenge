#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
WORKDIR /src/*.csproj ./aspnetapp
RUN dotnet restore --ignore-failed-sources

COPY . ./
WORKDIR /source/aspnetapp

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
EXPOSE 8081
ARG DEBIAN_FRONTEND=noninteractive
RUN apt-get update
RUN apt-get install tzdata -y
RUN ln -fs /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

WORKDIR /app

COPY --from=build /source/aspnetapp/out .
ENV ASPNETCORE_URLS=http://+:5000
ENV TZ="America/SAO_Paulo"

ENTRYPOINT ["dotnet", "Tech.Challenge.Grupo27.API.dll"]