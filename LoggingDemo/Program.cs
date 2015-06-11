using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace LoggingDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.ReadFrom.AppSettings()
                //.WriteTo.Trace()
                //.WriteTo.Console()
                //.WriteTo.ColoredConsole()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            Order order = new Order
            {
                Id = 123,
                Customer = new Customer
                {
                    Name = "Shaw",
                    Address = "123 Some Street"
                }
            };

            // Simple log4net/nlog replacement
            Console.WriteLine(@"Log.Information(""Processed order {0} by {1}"", order.Id, order.Customer);");
            Log.Information("Processed order {0} by {1}", order.Id, order.Customer);
            Console.ReadLine();

            // More Readable log4net/nlog replacement
            Console.WriteLine(@"Log.Information(""Processed order {orderId} by {customer}"", order.Id, order.Customer);");
            Log.Information("Processed order {orderId} by {customer}", order.Id, order.Customer);
            Console.ReadLine();

            // Serialize the customer property
            Console.WriteLine(@"Log.Information(""Processed order {orderId} by {@customer}"", order.Id, order.Customer);");
            Log.Information("Processed order {orderId} by {@customer}", order.Id, order.Customer);
            Console.ReadLine();

            // Or just serialize the whole order... as a string
            Console.WriteLine(@"Log.Information(""Processed order {order}"", order);");
            Log.Information("Processed order {order}", order);
            Console.ReadLine();

            // Or just serialize the whole order
            Console.WriteLine(@"Log.Information(""Processed order {@order}"", order);");
            Log.Information("Processed order {@order}", order);
            Console.ReadLine();

            Console.WriteLine(@"Log.Logger.BeginTimedOperation( ... );");
            using (Log.ForContext("CorrelationId", Guid.NewGuid())
                .BeginTimedOperation("Some Action", warnIfExceeds: TimeSpan.FromSeconds(2)))
            {
                var random = new Random(DateTimeOffset.UtcNow.Millisecond);
                var delay = random.Next(100, 3000);
                Log.Debug("Doing some things...");
                System.Threading.Thread.Sleep(delay);
                Log.Debug("I'm done with these things!");
            }
            Console.ReadLine();

            try
            {
                Console.WriteLine(@"throw new NotImplementedException(""Demonstrating an Exception"");");
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