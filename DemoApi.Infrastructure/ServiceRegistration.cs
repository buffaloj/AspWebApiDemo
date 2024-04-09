using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BufTools.DataStore;
using BufTools.DataStore.EntityFramework;

namespace DemoApi.Infrastructure
{
    /// <summary>
    /// Class to register Infrastructure related services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds infrastructure related dependencies to the service collection
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        /// <param name="connectionString">The connection string to the database</param>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            //services.AddScoped<IUnitOfWork, UnitOfWork<DataContext>>();

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("DemoApi.Infrastructure")),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            services.AddScoped<IStoreData, EntityFrameworkDataStore<DataContext>>();

            return services;
        }
    }
}
