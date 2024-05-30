using JobCandidates.Infrastructure.Abstract;
using JobCandidates.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JobCandidates.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
