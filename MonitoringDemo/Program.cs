using System;
using Metrics;
using MetricsDemo;

namespace MonitoringDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            Metric.Config
                .WithHttpEndpoint("http://localhost:1234/metrics/")
                .WithAllCounters();

            HealthChecks.RegisterHealthCheck(new FileHealthCheck());
            HealthChecks.RegisterHealthCheck(new DiskSpaceHealthCheck());

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
