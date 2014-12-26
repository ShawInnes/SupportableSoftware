using Autofac;
using TestabilityDemo.Services;

namespace TestabilityDemo.Modules
{
    public class ClockModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SelfIncrementingTestableClock>()
                .AsImplementedInterfaces();
        }
    }
}