# Use the ASP.NET runtime image as the base image for the final stage.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080  # Change to expose port 8080

# Use the .NET SDK image to build the application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WeatherForecastApp.csproj", "./"]
RUN dotnet restore "WeatherForecastApp.csproj"
COPY . .
RUN dotnet build "WeatherForecastApp.csproj" -c Release -o /app/build

# Publish the application.
FROM build AS publish
RUN dotnet publish "WeatherForecastApp.csproj" -c Release -o /app/publish

# Copy the published output to the final runtime image.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecastApp.dll"]
