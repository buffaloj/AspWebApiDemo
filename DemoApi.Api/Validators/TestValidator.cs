using DemoApi.Domain;
using FluentValidation;

namespace DemoApi.Api.Validators
{
    /// <summary>
    /// Validator for a <see cref="TestModel"/>
    /// </summary>
    [TestValidatorByExample]
    public class TestValidator : AbstractValidator<TestModel>
    {
        /// <summary>
        /// Constructs an instance of an object
        /// </summary>
        public TestValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Address).NotEmpty();
            RuleFor(t => t.DOB).NotEqual(DateTime.MinValue);
            RuleFor(t => t.ZipCode).NotEmpty();
            RuleFor(t => t.ZipCode).Length(5);
        }
    }
}
