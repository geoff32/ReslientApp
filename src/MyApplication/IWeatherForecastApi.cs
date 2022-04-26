using Refit;

namespace MyApplication
{
    public interface IWeatherForecastApi
    {
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }
}