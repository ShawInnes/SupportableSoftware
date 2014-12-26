using System;

namespace TestabilityDemo.Services
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
        DateTimeOffset UtcNow { get; }
    }
}