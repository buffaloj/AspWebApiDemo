using BufTools.DI.ReflectionHelpers;
using Microsoft.Extensions.DependencyInjection;
using DemoApi.DomainServices.Constants;

namespace DemoApi.DomainServices
{
    /// <summary>
    /// Class to register Domain Service related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds domain services related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScopedClassesWithAttribute<ServiceAttribute>(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}
