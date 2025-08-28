# Stage 1: Restore and build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY WeatherForecastApp.csproj ./
RUN dotnet restore WeatherForecastApp.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish WeatherForecastApp.csproj -c Release -o out

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 8080
EXPOSE 8080

# Set environment variable for ASP.NET Core to listen on port 8080
ENV ASPNETCORE_URLS=http://+