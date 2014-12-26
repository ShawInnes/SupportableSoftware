using System;

namespace TestabilityDemo.Services
{
    public class TestableClock : ITestableClock
    {
        public void SetClock(DateTimeOffset now)
        {
            Now = now;
        }

        public void Tick(TimeSpan ticks)
        {
            Now = Now.Add(ticks);
        }

        public void Tick(long ticks = 10000000)
        {
            Now = Now.AddTicks(ticks);
        }

        public DateTimeOffset Now { get; private set; }

        public DateTimeOffset UtcNow {
            get { return Now.ToUniversalTime(); }
        }
    }
}