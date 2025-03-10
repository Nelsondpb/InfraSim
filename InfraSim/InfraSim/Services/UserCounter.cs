using System;
using System.Threading.Tasks;

namespace InfraSim.Services
{
    public class UserCounter
    {
        public int Counter { get; private set; } = 0;
        public event Action? OnCounterChanged;

        public async Task StartIncrementing()
        {
            while (Counter < 200000)
            {
                Counter++ ;
                OnCounterChanged?.Invoke();
                await Task.Delay(2);
            }
        }
    }
}
