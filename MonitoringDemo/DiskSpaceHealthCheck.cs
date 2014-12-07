using Metrics;
using Metrics.Core;

namespace MetricsDemo
{
    public class DiskSpaceHealthCheck : HealthCheck
    {
        public DiskSpaceHealthCheck()
            : base("DiskSpaceHealthCheck")
        {
        }

        protected override HealthCheckResult Check()
        {
            int diskSpace = 100;

            if (diskSpace < 100)
            {
                return HealthCheckResult.Unhealthy("Insufficient Disk Space ({0}mb)", diskSpace);
            }

            return HealthCheckResult.Healthy("Disk Space OK ({0}mb)", diskSpace);
        }
    }
}