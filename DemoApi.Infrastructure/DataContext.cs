using BufTools.DataStore.EntityFramework;
using BufTools.DataStore.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure
{
    /// <summary>
    /// A context class used by DataStorage to know what class to use for storage
    /// </summary>
    public class DataContext : AutoRegisterDbContext
    {
        /// <summary>
        /// Constructs an instance of a context
        /// </summary>
        public DataContext(DbContextOptions options) : base(options)
        {
            RegisterEntities().WithAttribute<StoredDataAttribute>(typeof(Domain.ServiceRegistration).Assembly);
            RegisterViews().WithAttribute<StoredViewAttribute>(typeof(DomainServices.ServiceRegistration).Assembly);
            RegisterFunctions().WithAttribute<StoredFunctionAttribute>(typeof(DomainServices.ServiceRegistration).Assembly);
        }
    }
}
