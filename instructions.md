Can you create a Dockerfile for an ASP.NET Core app using .NET 8 with multi-stage build? I want it to restore, build, publish, and run the app using WeatherForecastApp.csproj
export port 8080


Generate a GitHub Actions workflow for building and deploying a Dockerized ASP.NET app to Azure. Use multi-stage builds, push to ACR, and deploy to Azure App Service. Include secrets like REGISTRY_USER, REGISTRY_PASSWORD, and AZURE_CREDENTIALS, and use environments named registry and production.