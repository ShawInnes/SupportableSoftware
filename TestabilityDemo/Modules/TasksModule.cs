using Autofac;
using TestabilityDemo.Tasks;

namespace TestabilityDemo.Modules
{
    public class TasksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthCheckTask>()
                .AsSelf();
        }
    }
}