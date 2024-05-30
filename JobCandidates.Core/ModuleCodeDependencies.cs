using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobCandidates.Core
{
    public static class ModuleCodeDependencies
    {
        public static IServiceCollection AddCodeDependencies(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
