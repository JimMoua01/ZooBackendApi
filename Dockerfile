# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set working directory
WORKDIR /app

# Copy solution and project files
COPY *.sln .
COPY ZooApi/*.csproj ./ZooApi/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY ZooApi/. ./ZooApi/
WORKDIR /app/ZooApi
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZooApi.dll"]