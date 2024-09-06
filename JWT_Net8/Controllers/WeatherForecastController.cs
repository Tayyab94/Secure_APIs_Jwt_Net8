using JWT_Net8.Models;
using JWT_Net8.Models.Infrastructire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Net8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TokenProvider tokenProvider;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TokenProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider;
            _logger = logger;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpPost]
        public async Task<string> login([FromBody] User model)
        {
            var user = new User()
            {
                Id = 1,
                Email = model.Email,
                Password =model.Password
            };
            var token = tokenProvider.Create(user);

            return token;
        }
    }
}
