using System;

namespace TestabilityDemo.Services
{
    public interface ITestableClock : IClock
    {
        void SetClock(DateTimeOffset now);
        void Tick(TimeSpan ticks);
        void Tick(long ticks = 10000000);
    }
}