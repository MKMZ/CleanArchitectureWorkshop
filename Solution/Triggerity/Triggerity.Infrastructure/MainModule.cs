using Autofac;
using Microsoft.Extensions.Configuration;

namespace Triggerity.Infrastructure
{
    public class MainModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public MainModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule(new AdapterModule());
            builder.RegisterModule(new AppModule());
        }

    }
}
