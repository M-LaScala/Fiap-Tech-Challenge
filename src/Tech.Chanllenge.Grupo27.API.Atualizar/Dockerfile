# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Tech.Chanllenge.Grupo27.API.Atualizar/Tech.Chanllenge.Grupo27.API.Atualizar.csproj", "src/Tech.Chanllenge.Grupo27.API.Atualizar/"]
RUN dotnet restore "src/Tech.Chanllenge.Grupo27.API.Atualizar/Tech.Chanllenge.Grupo27.API.Atualizar.csproj"

COPY . .
WORKDIR "/src/src/Tech.Chanllenge.Grupo27.API.Atualizar"
RUN dotnet build "Tech.Chanllenge.Grupo27.API.Atualizar.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tech.Chanllenge.Grupo27.API.Atualizar.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Verifica��o de conte�do
RUN echo "Conte�do de /app/publish:" && ls -la /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Adicione a vari�vel de ambiente para evitar erro de porta
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Tech.Chanllenge.Grupo27.API.Atualizar.dll"]