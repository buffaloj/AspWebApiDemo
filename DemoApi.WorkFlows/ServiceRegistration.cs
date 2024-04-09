using BufTools.DI.ReflectionHelpers;
using Microsoft.Extensions.DependencyInjection;
using DemoApi.WorkFlows.Constants;

namespace DemoApi.WorkFlows
{
    /// <summary>
    /// Class to register WorkFlow related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds application services related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        public static IServiceCollection AddWorkFlowServices(this IServiceCollection services)
        {
            services.AddScopedClassesWithAttribute<CommandAttribute>(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}
