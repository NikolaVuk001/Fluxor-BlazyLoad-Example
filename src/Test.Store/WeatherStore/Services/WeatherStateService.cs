using Fluxor;
using Test.Shared.Models;

namespace Test.Store.WeatherStore.Services
{
    public class WeatherStateService(IDispatcher dispatcher, IState<WeatherState> state)
    {
        public WeatherForecast[] Forecasts => state.Value.Forecasts;
        public void FetchWeatherData()
        {
            dispatcher.Dispatch(new FetchDataAction());
        }
        public void AddNewForecast()
        {
            dispatcher.Dispatch(new AddNewForecastAction());
        }
    }
}