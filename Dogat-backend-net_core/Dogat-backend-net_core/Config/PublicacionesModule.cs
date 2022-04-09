using Autofac;
using Dogat_backend_net_core.Adapters;
using Dogat_backend_net_core.Models;

namespace Dogat_backend_net_core.Config
{
    public class PublicacionesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PublicacionesAdapter>().As<IPublicacionesAdapter>().InstancePerLifetimeScope();
        }
    }
}
