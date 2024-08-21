using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DependencyResolver.Resolvers;

public class DefaultDependencyResolver : DependencyResolverBase
{
    public static IServiceCollection ResolveDependencies(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations)
    {
        return new DefaultDependencyResolver().LoadServices(services, assemblies, configurations);
    }
}
