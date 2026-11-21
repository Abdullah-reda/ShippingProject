using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<ApiResponse<IEnumerable<WeatherForecast>>> Get()
        {
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(ApiResponse<IEnumerable<WeatherForecast>>.SuccessResponse(forecasts));
        }
    }
}
