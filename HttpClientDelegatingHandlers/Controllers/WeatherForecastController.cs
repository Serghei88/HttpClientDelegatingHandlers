using Microsoft.AspNetCore.Mvc;

namespace HttpClientDelegatingHandlers.Controllers;


[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "Current")]
    public async Task<CurrentResponse?> Get(string city)
    {
        return  await _weatherService.GetCurrent(city);
    }
}