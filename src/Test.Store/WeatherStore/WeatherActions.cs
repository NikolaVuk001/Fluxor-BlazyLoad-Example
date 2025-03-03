using Test.Shared.Models;

namespace Test.Store.WeatherStore;

public record UpdateWeatherStateAction(DateOnly Date, WeatherForecast[] Forecasts);
public record UpdateWeatherStateActionWithDate(DateOnly Date);
public record UpdateWeatherStateActionWithForecasts(WeatherForecast[] Forecasts);
public record FetchDataAction();
public record AddNewForecastAction();