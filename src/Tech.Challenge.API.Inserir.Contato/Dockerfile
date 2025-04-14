# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8084
EXPOSE 8085

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Tech.Challenge.API.Inserir.Contato/Tech.Challenge.Grupo27.API.Inserir.Contato.csproj", "src/Tech.Challenge.API.Inserir.Contato/"]
RUN dotnet restore "./src/Tech.Challenge.API.Inserir.Contato/./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj"

COPY . .
WORKDIR "src/Tech.Challenge.API.Inserir.Contato"
RUN dotnet build "./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tech.Challenge.Grupo27.API.Inserir.Contato.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Verifica��o de conte�do
RUN echo "Conte�do de /app/publish:" && ls -la /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Adicione a vari�vel de ambiente para evitar erro de porta
ENV ASPNETCORE_URLS=http://+:8084

ENTRYPOINT ["dotnet", "Tech.Challenge.Grupo27.API.Inserir.Contato.dll"]