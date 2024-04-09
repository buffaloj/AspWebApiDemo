namespace DemoApi.Api.Extensions
{
    /// <summary>
    /// A class to group Swagger extensions
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Adds Swagger to the collection and provides the XML files needed for it to consume examples
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in loadedAssemblies)
                {
                    var path = assembly.ToXmlPath();
                    if (File.Exists(path))
                        options.IncludeXmlComments(path);
                }
            });

            return services;
        }
    }
}
