using System;

namespace TestabilityDemo.Services
{
    public class SystemClock : IClock
    {
        public DateTimeOffset Now { get { return DateTimeOffset.Now; } }
        public DateTimeOffset UtcNow { get { return DateTimeOffset.UtcNow; } }
    }
}