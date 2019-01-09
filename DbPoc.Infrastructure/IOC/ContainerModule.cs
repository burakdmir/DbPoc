using Autofac;
using DbPoc.Common;
using DbPoc.Infrastructure.Behaviours;
using MediatR;

namespace DbPoc.Infrastructure.IOC
{
    class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ExceptionPipelineBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(PerformancePipelineBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterType<SystemTime>().As<ISystemTime>();
        }
    }
}
