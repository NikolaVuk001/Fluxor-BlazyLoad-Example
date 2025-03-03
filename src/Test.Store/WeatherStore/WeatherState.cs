using Fluxor;
using Test.Shared.Models;

namespace Test.Store.WeatherStore
{
    [FeatureState]
    public class WeatherState
    {
        public DateOnly Date { get; }
        public WeatherForecast[] Forecasts { get; } = new WeatherForecast[0];

        public WeatherState()
        {

        }
        public WeatherState(DateOnly date, WeatherForecast[] forecasts)
        {
            Date = date;
            Forecasts = forecasts;
        }
    }
}