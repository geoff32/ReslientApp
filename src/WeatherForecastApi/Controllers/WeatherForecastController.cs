using Microsoft.AspNetCore.Mvc;
using WeatherForecastApi.Infrastructure;

namespace WeatherForecastApi.Controllers;

[ApiController]
[Route("weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastController> logger)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {
        return Ok(_weatherForecastRepository.Get());
    }
}
