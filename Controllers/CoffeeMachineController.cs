using CoffeeMachine.Api.Services;
using CoffeeMachineAPI.Models;
using CoffeeMachineAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeCounterService _counterService;
        private readonly IWeatherService _weatherService;

        // Dependency inject both the coffee counter and weather services
        public CoffeeMachineController(ICoffeeCounterService counterService, IWeatherService weatherService)
        {
            _counterService = counterService;
            _weatherService = weatherService;
        }


        [HttpGet("brew-coffee")]
        public async Task<IActionResult> BrewCoffee()
        {
            // 1. April Fools Check
            var today = DateTime.Today;
            if (today.Month == 4 && today.Day == 1)
            {
                return StatusCode(418);
            }

            // 2. Coffee Empty Check
            if (_counterService.IsOutOfCoffee())
            {
                return StatusCode(503);
            }

            // 3. Weather Check
            // We use a try/catch so if the weather API goes down, we still give the customer hot coffee!
            double currentTemp = 0;
            try
            {
                currentTemp = await _weatherService.GetCurrentTemperatureAsync();
            }
            catch
            {
                // Log error here in a real app, default to hot coffee
            }

            var message = currentTemp > 30
                ? "Your refreshing iced coffee is ready"
                : "Your piping hot coffee is ready";

            // 4. Brew
            var response = new CoffeeResponse
            {
                Message = message,
                Prepared = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzz").Replace(":", "")
                //Prepared = DateTime.UtcNow

            };

            return Ok(response);
        }
    }
}