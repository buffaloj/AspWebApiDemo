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
using BufTools.ObjectCreation.FromXmlComments.Resources;
using System.IO;
using BufTools.Extensions.Reflection;
using BufTools.Extensions.XmlComments;

namespace DemoApi.Architecture.Tests
{
    [TestClass]
    public class AllValidatorsTests
    {
        [TestMethod]
        public async Task AllValidators_EnforcePassFailValues()
        {
            var errors = new List<string>();
            var services = new ServiceCollection();

            var assemblies = new List<Assembly>
            {
                typeof(Api.ServiceRegistration).Assembly,
                typeof(Domain.ServiceRegistration).Assembly
            };

            foreach (var assembly in assemblies)
            {
                var validatorTypes = assembly.GetClasses<IValidator>();
                foreach (var type in validatorTypes)
                    services.AddSingleton(type);
            }

            var provider = services.BuildServiceProvider();
            foreach (var assembly in assemblies)
                errors.AddRange(await GetEnforcementErrors(assembly, provider));

            Assert.IsFalse(errors.Any());
        }

        private async Task<IEnumerable<string>> GetEnforcementErrors(Assembly assembly, ServiceProvider provider)
        { 
            var xmlDocs = assembly.LoadXmlDocumentation();

            var errors = new List<string>();

            var validatorTypes = assembly.GetClasses<IValidator>();
            foreach (var type in validatorTypes)
            {
                var classDoc = xmlDocs.GetDocumentation(type);
                if (classDoc == null)
                {
                    errors.Add($"Validator of {type} does not have any XML documentation.  Please add before continuing.");
                    continue;
                }

                if (classDoc.PassValues.Any() || classDoc.FailValues.Any())
                {
                    var validator = provider.GetService(type) as IValidator;
                    if (validator == null)
                        continue;   

                    foreach (var pass in classDoc.PassValues)
                    {
                        if (!GetContext(pass, validator, ref errors, out var context))
                            continue; 

                        var result = await validator.ValidateAsync(context);
                        if (!result.IsValid)
                            errors.Add($"{type.Name} did not pass with '{pass}' (Errors: {result.Errors})");
                    }

                    foreach (var fail in classDoc.FailValues)
                    {
                        if (!GetContext(fail, validator, ref errors, out var context))
                            continue;

                        var result = await validator.ValidateAsync(context);
                        if (result.IsValid)
                            errors.Add($"{type.Name} did not fail with '{fail}'");
                    }
                }
            }

            return errors;
        }

        private bool GetContext(string value, IValidator validator, ref List<string> errors, out IValidationContext context)
        {
            try
            {
                context = GetContext(value, validator);
                return true;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                context = null;
                return false;
            }
        }

        private IValidationContext GetContext(string value, IValidator validator)
        {
            if (validator.CanValidateInstancesOfType(typeof(string)))
                return new ValidationContext<string>(value);

            if (validator.CanValidateInstancesOfType(typeof(int?)))
                return new ValidationContext<int?>(string.IsNullOrWhiteSpace(value) ? default(int?) : int.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(int)))
                return new ValidationContext<int>(int.Parse(value));

            if (validator.CanValidateInstancesOfType(typeof(float?)))
                return new ValidationContext<float?>(string.IsNullOrWhiteSpace(value) ? default(float?) : float.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(float)))
                return new ValidationContext<float>(float.Parse(value));

            if (validator.CanValidateInstancesOfType(typeof(short?)))
                return new ValidationContext<short?>(string.IsNullOrWhiteSpace(value) ? default(short?) : short.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(short)))
                return new ValidationContext<short>(short.Parse(value));

            if (validator.CanValidateInstancesOfType(typeof(long?)))
                return new ValidationContext<long?>(string.IsNullOrWhiteSpace(value) ? default(long?) : long.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(long)))
                return new ValidationContext<long>(long.Parse(value));

            if (validator.CanValidateInstancesOfType(typeof(decimal?)))
                return new ValidationContext<decimal?>(string.IsNullOrWhiteSpace(value) ? default(decimal?) : decimal.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(decimal)))
                return new ValidationContext<decimal>(decimal.Parse(value));

            if (validator.CanValidateInstancesOfType(typeof(DateTime?)))
                return new ValidationContext<DateTime?>(string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value));
            if (validator.CanValidateInstancesOfType(typeof(DateTime)))
                return new ValidationContext<DateTime>(DateTime.Parse(value));

            // TODO: Change to a domain specific exception
            throw new Exception($"{validator.GetType().Name} - {value} - Only plain data types are supported(int, float, short, long, and decimal, DateTime, and nullable versions of those)");
        }

        [TestMethod]
        public void ObjectMotherTest()
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

            var provider = services.BuildServiceProvider();

            var mother = new ObjectMother(provider);

            //***
            var assembly2 = typeof(Recipe).Assembly;
            string text = Path.Combine(assembly2.GetDirectoryPath(), assembly2.GetName().Name + ".xml");
            if (!File.Exists(text))
            {
                throw new FileNotFoundException(string.Format(ProjectResources.XmlFileNotFound, text));
            }
            //***

            var recipe = mother.Birth<Recipe>();

            Assert.IsNotNull(recipe);
        }
    }
}
