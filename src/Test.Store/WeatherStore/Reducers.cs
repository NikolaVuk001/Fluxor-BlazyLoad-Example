using Fluxor;

namespace Test.Store.WeatherStore;

public class Reducers
{
    [ReducerMethod]
    public static WeatherState ReduceUpdateWeatherStateAction(WeatherState state, UpdateWeatherStateAction action) =>
        new WeatherState(action.Date, action.Forecasts);
}