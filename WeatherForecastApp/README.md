# Weather Forecast Application

## Overview
The Weather Forecast Application is a simple .NET 8 web application that provides weather forecast data. It includes a controller for handling HTTP requests and a model representing the weather forecast data.

## Project Structure
```
WeatherForecastApp
├── Controllers
│   ├── WeatherForecastController.cs
│   └── WeatherForecastControllerTest.cs
├── Models
│   └── WeatherForecast.cs
├── Properties
│   └── launchSettings.json
├── WeatherForecastApp.csproj
├── Program.cs
└── README.md
```

## Features
- **WeatherForecastController**: Handles HTTP requests related to weather forecasts and provides a method to retrieve a list of forecasts.
- **WeatherForecast Model**: Represents a weather forecast with properties such as date, temperature in Celsius and Fahrenheit, and a summary.
- **Unit Tests**: Ensures the functionality of the controller using the Xunit framework.

## Getting Started

### Prerequisites
- .NET 8 SDK
- A code editor (e.g., Visual Studio Code)

### Running the Application
1. Clone the repository or download the project files.
2. Open a terminal and navigate to the project directory.
3. Run the following command to restore dependencies:
   ```
   dotnet restore
   ```
4. Start the application using:
   ```
   dotnet run
   ```
5. Access the application in your web browser at `http://localhost:5000`.

### Running Tests
To run the unit tests for the WeatherForecastController, use the following command:
```
dotnet test
```

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.