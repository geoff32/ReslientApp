using System.Net.Sockets;
using Polly.Contrib.Simmy;
using Polly.Contrib.Simmy.Outcomes;

namespace WeatherForecastApi.Infrastructure
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly WeatherForecast[] _weatherForecastArray;
        private readonly InjectOutcomePolicy _chaosPolicy;

        public WeatherForecastRepository()
        {
            _weatherForecastArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _chaosPolicy = MonkeyPolicy.InjectException(with =>
                with
                    .Fault(new SocketException(errorCode: 10013))
                    .InjectionRate(0.33)
                    .Enabled()
            );
        }

        public IEnumerable<WeatherForecast> Get()
            => _chaosPolicy.Execute<IEnumerable<WeatherForecast>>(() => _weatherForecastArray.AsEnumerable());
    }
}