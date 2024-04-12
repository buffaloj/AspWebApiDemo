using BufTools.DataStore;
using DemoApi.Domain.Models;
using DemoApi.DomainServices.Constants;
using System;
using System.Linq;

namespace DemoApi.DomainServices.Services
{
    /// <summary>
    /// A set of Recipe related methods
    /// </summary>
    [Service]
    public class RecipeService
    {
        private readonly IStoreData _dataStore;

        /// <summary>
        /// Constructs an instance of an object
        /// </summary>
        /// <param name="dataStore">An instance used to save and retreive data</param>
        /// <exception cref="ArgumentNullException">Thrown if any required dependency is null</exception>
        public RecipeService(IStoreData dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        /// <summary>
        /// Gets a query to fetch a <see cref="Recipe"/> by ID
        /// </summary>
        /// <param name="id">The id of the recipe</param>
        /// <returns>An <see cref="IQueryable"/> instance used to fetch a <see cref="Recipe"/> </returns>
        public IQueryable<Recipe> GetRecipe(int id)
        {
            return _dataStore.Get<Recipe>().Where(p => p.Id == id);
        }
    }
}
