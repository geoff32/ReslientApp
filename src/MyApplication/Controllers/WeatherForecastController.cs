using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastApi _weatherForecastApi;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherForecastApi weatherForecastApi, ILogger<WeatherForecastController> logger)
    {
        _weatherForecastApi = weatherForecastApi;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        return  await _weatherForecastApi.GetAsync();
    }
}
