#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8084
EXPOSE 8085

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Tech.Challenge.API.Inserir.Contato/Tech.Challenge.Grupo27.API.Inserir.Contato.csproj", "src/Tech.Challenge.API.Inserir.Contato/"]
RUN dotnet restore "./src/Tech.Challenge.API.Inserir.Contato/./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj"
COPY . .
WORKDIR "src/Tech.Challenge.API.Inserir.Contato"
RUN dotnet build "./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tech.Challenge.API.Inserir.Contato.dll"]