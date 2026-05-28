namespace CoffeeMachineAPI.Services
{
    public class CoffeeCounterService : ICoffeeCounterService
    {
        private int _callCount = 0;
        public bool IsOutOfCoffee()
        {
            int currentCount = Interlocked.Increment(ref _callCount);
            return currentCount % 5 == 0; // Simulate out of coffee every 5th call
        }
    }
}
