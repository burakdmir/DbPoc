using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DbPoc.Infrastructure.IOC
{
    public static class Bootstrap
    {

        public static IServiceProvider Initialize(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            Assembly[] assemblies = GetAssemblies();
            builder.RegisterAssemblyModules(assemblies);
            return new AutofacServiceProvider(builder.Build());
        }

        private static Assembly[] GetAssemblies()
        {

            HashSet<Assembly> assemblies = new HashSet<Assembly>();

            IReadOnlyList<CompilationLibrary> dependencies = DependencyContext.Default.CompileLibraries;
            foreach (CompilationLibrary library in dependencies)
            {
                if (library.Name.ToLower().Contains("dbpoc"))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }

            return assemblies.ToArray();
        }
    }
}
