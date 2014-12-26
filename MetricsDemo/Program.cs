using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrics;

namespace MetricsDemo
{
    static class Program
    {
        private static readonly Timer timer = Metric.Timer("Requests", Unit.Requests);
        private static readonly Counter counter = Metric.Counter("ConcurrentRequests", Unit.Requests);

        private static readonly Meter meter = Metric.Meter("MyMeter", Unit.KiloBytes, TimeUnit.Seconds,
            new MetricTags("kilobytes"));

        private static Random random = new Random(123);

        private static void Process(string inputString)
        {
            counter.Increment();
            using (timer.NewContext())
            {
                // do something to time
                System.Threading.Thread.Sleep(120);
            }

            meter.Mark(random.Next(1500));

            counter.Decrement();
        }

        static void Main(string[] args)
        {
            Metric.Config
                .WithHttpEndpoint("http://localhost:1234/metrics/")
                .WithReporting(p => p.WithElasticSearch("10.0.1.87", 9200, "metrics", TimeSpan.FromSeconds(1)))
                .WithReporting(p => p.WithConsoleReport(TimeSpan.FromSeconds(10)))
                .WithAllCounters();

            Console.WriteLine("Waiting... Hit a key to fire off a bunch of metric events");
            Console.ReadKey();

            for (int i = 0; i < 10000; i++)
            {
                Process(i.ToString());
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
