using Autofac;
using DbPoc.Infrastructure.Behaviours;
using MediatR;

namespace DbPoc.Infrastructure.IOC
{
    class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(PerformancePipelineBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
