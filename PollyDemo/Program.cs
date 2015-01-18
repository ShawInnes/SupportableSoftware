using System;
using System.Net.Http;
using Serilog;

namespace PollyDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            var svc = new FaultResistentService();

            // This request should work
            try
            {
                var response = svc.DemoCall(@"http://google.com/");
                Log.Information("DemoCall returned {string}", response);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "HttpClient Request Failed");
            }

            // This request should fail (invalid domain name)
            // (until such time that .xyz becomes a valid TLD)
            // it will retry a number of times first though
            try
            {
                var response = svc.DemoCall(@"http://google.xyz/");
                Log.Information("DemoCall returned {string}", response);
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "HttpClient Request Failed");
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}