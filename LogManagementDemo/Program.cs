using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Context;
using SerilogMetrics;

namespace LogManagementDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341/")
                .Enrich.WithProperty("ComputerName", System.Net.Dns.GetHostName())
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole()
                //.WriteTo.ColoredConsole(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {CorrelationId} {Message}{NewLine}{Exception}")
                .CreateLogger();

            // We can push extra properties into our log context for a given scope
            // We can then filter in Seq like so: order.Items[?].Name == "Mouse"
            using (LogContext.PushProperty("CorrelationId", Guid.NewGuid()))
            {
                Order order = new Order
                {
                    Id = 123,
                    Customer = new Customer
                    {
                        Name = "Shaw",
                        Address = "123 Some Street"
                    },
                    Items = new List<Item>
                    {
                        new Item("MacBook Pro"),
                        new Item("Mouse"),
                        new Item("iPhone 83")
                    }
                };

                // Simple log4net/nlog replacement
                Log.Information("Processed order {0} by {1}", order.Id, order.Customer);

                // Serialize the customer property
                Log.Information("Processed order {orderId} by {@customer}", order.Id, order.Customer);

                // Or just serialize the whole order
                Log.Information("Processed order {@order}", order);
            }

            using (LogContext.PushProperty("CorrelationId", Guid.NewGuid()))
            using (Log.Logger.BeginTimedOperation("Some Action", warnIfExceeds: TimeSpan.FromSeconds(2)))
            {
                var random = new Random(DateTimeOffset.UtcNow.Millisecond);
                var delay = random.Next(100, 3000);
                Log.Debug("Doing some things...");
                System.Threading.Thread.Sleep(delay);
                Log.Debug("I'm done with these things!");
            }

            try
            {
                throw new NotImplementedException("Demonstrating an Exception");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something broke");
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}