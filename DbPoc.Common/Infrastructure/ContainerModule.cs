using Autofac;

namespace DbPoc.Common.Infrastructure
{
    class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemTime>().AsSelf();
        }
    }
}
