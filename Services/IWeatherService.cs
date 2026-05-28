using System.Threading.Tasks;

namespace CoffeeMachine.Api.Services
{
    public interface IWeatherService
    {
        Task<double> GetCurrentTemperatureAsync();
    }
}