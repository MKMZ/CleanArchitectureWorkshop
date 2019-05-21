using Autofac;
using Triggerity.App.UseCases;
using Triggerity.Definitions;

namespace Triggerity.Infrastructure
{
    internal class AppModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SetupAllCompanyTriggerOrderUseCase>()
                .As<ICommandHandler<SetupAllCompanyTriggerOrderCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GiveTriggerUseCase>()
                .As<ICommandHandler<GiveTriggerCommand>>()
                .InstancePerLifetimeScope();
        }
    }
}
