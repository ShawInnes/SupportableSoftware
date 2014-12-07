using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace LoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
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
            Log.Information("Processed order {orderId} by {customer}", order.Id, order.Customer);

            // Serialize the customer property
            Log.Information("Processed order {orderId} by {@customer}", order.Id, order.Customer);

            // Or just serialize the whole order
            Log.Information("Processed order {@order}", order);

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
