using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FluentScheduler;
using Serilog;
using TestabilityDemo.Services;
using TestabilityDemo.Tasks;

namespace TestabilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            var builder = new ContainerBuilder();

            // Scan this assembly for components
            builder.RegisterAssemblyModules(typeof(Program).Assembly);

            using (var container = builder.Build())
            {
                try
                {
                    TaskManager.TaskFactory = new AutofacTaskFactory(container);
                    
                    TaskManager.TaskStart += (schedule, e) => Log.Information("{Name} Started @ {Time} ", schedule.Name, schedule.StartTime);
                    TaskManager.TaskEnd += (schedule, e) => Log.Information("{Name} Ended. Started @ {Time}. Duration {Duration}. Next Run {NextRun}", schedule.Name, schedule.StartTime, schedule.Duration, schedule.NextRunTime);

                    TaskManager.Initialize(new TaskRegistry());

                    var clock = container.Resolve<ITestableClock>();
                    clock.SetClock(DateTimeOffset.Now);

                    Log.Information("Now it is {Time}", clock.Now);

                    Log.Information("Now it is {Time}", clock.Now);
                    
                    Log.Information("Now it is {Time}", clock.Now);

                    Console.WriteLine("Done.");
                    Console.ReadLine();
                }
                catch (Autofac.Core.Registration.ComponentNotRegisteredException ex)
                {
                    Log.Error(ex, "Exception in IOC");

                    Console.WriteLine("Exeption Caught");
                    Console.ReadLine();
                }
            }
        }
    }
}
