using Autofac;
using Dogat_backend_net_core.Adapters.Publicaciones;
using Dogat_backend_net_core.Adapters.Usuarios;
using Dogat_backend_net_core.Models.Publicaciones;
using Dogat_backend_net_core.Models.Usuarios;

namespace Dogat_backend_net_core.Config
{
    public class PublicacionesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PublicacionesAdapter>().As<IPublicacionesAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<UsuariosAdapter>().As<IUsuariosAdapter>().InstancePerLifetimeScope();
        }
    }
}
