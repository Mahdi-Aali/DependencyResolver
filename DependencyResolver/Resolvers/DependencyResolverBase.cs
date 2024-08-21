using DependencyResolver.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DependencyResolver.Resolvers;

public abstract class DependencyResolverBase
{
    public virtual IServiceCollection LoadServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configuration)
    {
        Type[] serviceProviders = assemblies.SelectMany(asm => asm.ExportedTypes.Where(x => typeof(IDependencyProvider).IsAssignableFrom(x))).ToArray();
        foreach(Type provider in serviceProviders)
        {
            IDependencyProvider dependencyProvider = (IDependencyProvider)Activator.CreateInstance(provider)!;
            dependencyProvider.GetServices(services, assemblies, configuration);
        }
        return services;
    }
}