namespace DemoApi.Api
{
    /// <summary>
    /// Class to register API related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds application services related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            return services;
        }
    }
}
