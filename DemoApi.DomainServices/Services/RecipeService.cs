using BufTools.DataStore;
using DemoApi.Domain.Models;
using DemoApi.DomainServices.Constants;
using System;
using System.Linq;

namespace DemoApi.DomainServices.Services
{
    [Service]
    public class RecipeService
    {
        private readonly IStoreData _dataStore;
        public RecipeService(IStoreData dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException($"{dataStore} cannot be null");
        }

        public IQueryable<Recipe> GetRecipe(int id)
        {
            return _dataStore.Get<Recipe>().Where(p => p.Id == id);
        }
    }
}
