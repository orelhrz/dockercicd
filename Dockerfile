# Stage 1: Restore and build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore WeatherForecastApp.csproj
RUN dotnet build WeatherForecastApp.csproj -c Release --no-restore
RUN dotnet publish WeatherForecastApp.csproj -c Release -o /app/publish --no-build

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "WeatherForecastApp.dll"]