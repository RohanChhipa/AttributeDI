using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestApi.Services;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TestService _testService;

        // The Web API will only accept tokens 1) for users, and 2) having the access_as_user scope for this API
        static readonly string[] scopeRequiredByApi = new string[] {"access_as_user"};

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet]
        public double Get()
        {
            return _testService.DoStuff();
        }
    }
}