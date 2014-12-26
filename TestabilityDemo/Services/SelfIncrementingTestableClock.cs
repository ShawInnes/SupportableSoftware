using System;

namespace TestabilityDemo.Services
{
    public class SelfIncrementingTestableClock : ITestableClock
    {
        private DateTimeOffset now;

        public void SetClock(DateTimeOffset now)
        {
            this.now = now;
        }

        public void Tick(TimeSpan ticks)
        {
            this.now = now.Add(ticks);
        }

        public void Tick(long ticks = 10000000)
        {
            this.now = now.AddTicks(ticks);
        }

        public DateTimeOffset Now
        {
            get
            {
                Tick();
                return now;
            }
            private set
            {
                now = value;
            }
        }

        public DateTimeOffset UtcNow
        {
            get
            {
                Tick();
                return Now.ToUniversalTime();
            }
        }
    }
}