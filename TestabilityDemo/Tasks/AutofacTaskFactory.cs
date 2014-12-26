using System;
using Autofac;
using FluentScheduler;
using Serilog;

namespace TestabilityDemo.Tasks
{
    public class AutofacTaskFactory : ITaskFactory
    {
        private readonly IContainer container;

        public AutofacTaskFactory(IContainer container)
        {
            this.container = container;
        }

        public ITask GetTaskInstance<T>() where T : ITask
        {
            Log.Information("Creating Task {Task}", typeof(T).Name);
            
            try
            {
                return container.Resolve<T>();
            }
            catch (Autofac.Core.Registration.ComponentNotRegisteredException ex)
            {
                Log.Fatal(ex, "Unable to resolve component {Type}", typeof(T).FullName);
            }
            
            return null;
        }
    }
}