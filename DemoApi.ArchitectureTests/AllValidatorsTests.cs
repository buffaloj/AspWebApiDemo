using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using BufTools.ObjectCreation.FromXmlComments;
using DemoApi.Domain.Models;
using DemoApi.Domain;
using BufTools.Extensions.DependencyInjection;
using BufTools.FluentValidation.TestByExample;

namespace DemoApi.Architecture.Tests
{
    [TestClass]
    public class AllValidatorsTests
    {
        private readonly TestValidatorsByExample _exampleTester = new();

        private IEnumerable<Assembly> AllAssemblies => new List<Assembly>
            {
                typeof(Api.ServiceRegistration).Assembly,
                typeof(Domain.ServiceRegistration).Assembly,
                typeof(DomainServices.ServiceRegistration).Assembly
            };

        [TestMethod]
        public async Task AllValidators_EnforcePassFailValues()
        {
            var services = new ServiceCollection();
            var types = services.AddSingletonClassesWithAttribute<TestValidatorByExampleAttribute>(AllAssemblies);

            var errors = await _exampleTester.GetValidationErrors(services, types);

            Assert.IsFalse(errors.Any(), "\n" + string.Join("\n", errors));
        }

        [TestMethod]
        public void ObjectMotherTest()
        {
            var provider = BuildProvider();
            var mother = new ObjectMother(provider);

            var recipe = mother.Birth<Recipe>();

            Assert.IsNotNull(recipe);
        }

        private IServiceProvider BuildProvider()
        {
            var services = new ServiceCollection();

            var assemblies = new List<Assembly>
            {
                typeof(Api.ServiceRegistration).Assembly,
                typeof(Domain.ServiceRegistration).Assembly,
                typeof(DomainServices.ServiceRegistration).Assembly
            };

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t => t.IsClass &&
                                                           t.GetConstructor(Type.EmptyTypes) != null &&
                                                           !t.IsAbstract);
                foreach (var type in types)
                    services.AddTransient(type);
            }

            return services.BuildServiceProvider();
        }
    }
}
