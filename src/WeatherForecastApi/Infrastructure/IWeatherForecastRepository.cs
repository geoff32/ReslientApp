namespace WeatherForecastApi.Infrastructure
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}