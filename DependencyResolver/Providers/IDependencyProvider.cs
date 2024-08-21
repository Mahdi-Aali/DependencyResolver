using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DependencyResolver.Providers;

public interface IDependencyProvider
{
    public IServiceCollection GetServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations);
}
