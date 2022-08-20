namespace GovHack22API.Controllers;

using GovHack22API.Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyContext _dbContext;

    public PropertyController(PropertyContext dbContext)
    {
        _dbContext = dbContext;
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    // [HttpPost(Name = "CreatePropertyPost")]
    // public IHttpActionResult Get()
    // {

    //      return Ok();
    // }

}
