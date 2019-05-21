using Autofac;
using Triggerity.Adapters;
using Triggerity.Domain;

namespace Triggerity.Infrastructure
{
    internal class AdapterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CompanyRepository>()
                .As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PersonRepository>()
                .As<IPersonRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TreasuryRepository>()
                .As<ITreasuryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TriggerOrderRepository>()
                .As<ITriggerOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TriggerRepository>()
                .As<ITriggerRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
