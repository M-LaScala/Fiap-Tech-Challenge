#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Tech.Challenge.Grupo27.API/Tech.Challenge.Grupo27.API.Contato.csproj", "src/Tech.Challenge.Grupo27.API/"]
RUN dotnet restore "./src/Tech.Challenge.Grupo27.API/./Tech.Challenge.Grupo27.API.Contato.csproj"

COPY . .
WORKDIR "src/Tech.Challenge.Grupo27.API"
RUN dotnet build "./Tech.Challenge.Grupo27.API.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tech.Challenge.Grupo27.API.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Verifica��o de conte�do
RUN echo "Conte�do de /app/publish:" && ls -la /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Adicione a vari�vel de ambiente para evitar erro de porta
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Tech.Challenge.Grupo27.API.Contato.dll"]