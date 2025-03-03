using Fluxor;
using Test.Shared.Models;

namespace Test.Store.WeatherStore;

public class Effects(IState<WeatherState> state)
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    [EffectMethod]
    public Task HandleUpdateWeatherStateActionWithDate(UpdateWeatherStateActionWithDate action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new UpdateWeatherStateAction(action.Date, state.Value.Forecasts));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleUpdateWeatherStateActionWithForecasts(UpdateWeatherStateActionWithForecasts action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new UpdateWeatherStateAction(state.Value.Date, state.Value.Forecasts));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await FetchWeatherForecasts();
        dispatcher.Dispatch(new UpdateWeatherStateAction(state.Value.Date, forecasts));
    }

    [EffectMethod]
    public Task HandleAddNewForecastAction(AddNewForecastAction action, IDispatcher dispatcher)
    {
        var newForecast = new WeatherForecast
        {
            Date = state.Value.Date.AddDays(1),
            TemperatureC = 0,
            Summary = Summaries[0]
        };
        var newForecasts = state.Value.Forecasts.Append(newForecast).ToArray();
        dispatcher.Dispatch(new UpdateWeatherStateAction(state.Value.Date, newForecasts));
        return Task.CompletedTask;
    }

    private async Task<WeatherForecast[]> FetchWeatherForecasts()
    {
        // This is where you would make a call to a web service to get real data
        await Task.Delay(1000);
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = state.Value.Date.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }).ToArray();
    }




}