using JobCandidates.Service.Abstract;
using JobCandidates.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace JobCandidates.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICandidateService, CandidateService>();
            return services;
        }
    }
}
