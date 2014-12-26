using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler;
using Serilog;
using TestabilityDemo.Services;

namespace TestabilityDemo.Tasks
{
    public class HealthCheckTask : ITask
    {
        private readonly IClock clock;

        public HealthCheckTask(IClock clock)
        {
            this.clock = clock;
        }

        public void Execute()
        {
            Log.Information("Health Check Task using clock {Type}", clock.GetType().Name);
        }
    }
}
