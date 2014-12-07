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

        public static void Process(string inputString)
        {
            counter.Increment();
            using (timer.NewContext())
            {
                // do something to time
                System.Threading.Thread.Sleep(120);
            }
      }

        static void Main(string[] args)
        {
            Metric.Config
                .WithHttpEndpoint("http://localhost:1234/metrics/")
                .WithAllCounters();

            Console.WriteLine("Waiting... Hit a key to fire off a bunch of metric events");
            Console.ReadKey();

            for (int i = 0; i < 100; i++)
            {
                Process(i.ToString());   
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
