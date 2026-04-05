# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy project files only
COPY ZooApi/*.csproj ./ZooApi/

# Restore dependencies directly from the project
RUN dotnet restore ./ZooApi/ZooApi.csproj

# Copy all source files
COPY ZooApi/. ./ZooApi/

# Build and publish
WORKDIR /app/ZooApi
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZooApi.dll"]