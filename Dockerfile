# Use official .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ZooApi/*.csproj ./ZooApi/
RUN dotnet restore

# Copy everything else and build
COPY ZooApi/. ./ZooApi/
WORKDIR /app/ZooApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/ZooApi/out ./

# Expose port (Render expects 10000 by default)
EXPOSE 10000

# Run the API
ENTRYPOINT ["dotnet", "ZooApi.dll"]