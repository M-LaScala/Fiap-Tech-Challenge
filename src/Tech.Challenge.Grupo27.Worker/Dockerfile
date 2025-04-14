# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8086
EXPOSE 8087

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Tech.Challenge.Grupo27.Worker/Tech.Challenge.Grupo27.Worker.csproj", "src/Tech.Challenge.Grupo27.Worker/"]
RUN dotnet restore "./src/Tech.Challenge.Grupo27.Worker/./Tech.Challenge.Grupo27.Worker.csproj"

COPY . .
WORKDIR "src/Tech.Challenge.Grupo27.Worker"
RUN dotnet build "./Tech.Challenge.Grupo27.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tech.Challenge.Grupo27.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Verifica��o de conte�do
RUN echo "Conte�do de /app/publish:" && ls -la /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Adicione a vari�vel de ambiente para evitar erro de porta
ENV ASPNETCORE_URLS=http://+:8086

ENTRYPOINT ["dotnet", "Tech.Challenge.Grupo27.Worker.dll"]