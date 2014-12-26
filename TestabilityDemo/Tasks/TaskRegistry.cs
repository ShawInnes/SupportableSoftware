using FluentScheduler;
using Serilog;

namespace TestabilityDemo.Tasks
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            Log.Information("Instantiating TaskRegistry");

            Schedule<HealthCheckTask>()
                .ToRunNow()
                .AndEvery(30)
                .Seconds();
        }
    }
}