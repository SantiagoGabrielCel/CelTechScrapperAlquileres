# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todo el contenido
COPY . .

# Restaurar dependencias
RUN dotnet restore CelTechScrapper.sln

# Publicar en modo Release
RUN dotnet publish ./CelTechScrapper/CelTechScrapper.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "CelTechScrapper.dll"]
