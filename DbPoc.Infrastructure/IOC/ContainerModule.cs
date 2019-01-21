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
            builder.RegisterGeneric(typeof(ExceptionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPerformancePipelineBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(CacheBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterType<SystemTime>().As<ISystemTime>();
        }
    }
}
