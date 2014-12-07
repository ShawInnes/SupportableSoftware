using Metrics;
using Metrics.Core;

namespace MetricsDemo
{
    public class FileHealthCheck : HealthCheck
    {
        public FileHealthCheck() : base("FileHealthCheck")
        {
        }

        protected override HealthCheckResult Check()
        {
            if (System.IO.File.Exists(@"C:\blah.txt"))
            {
                return HealthCheckResult.Healthy("Yep, the file is there");
            }
            else
            {
                return HealthCheckResult.Unhealthy("Nope it's not there");
            }
        }
    }
}