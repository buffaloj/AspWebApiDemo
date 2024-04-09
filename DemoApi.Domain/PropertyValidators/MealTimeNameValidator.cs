using DemoApi.Domain.Resources;
using FluentValidation;

namespace DemoApi.Domain.PropertyValidators
{
    /// <summary>
    /// Validates an mealtime name
    /// </summary>
    /// <shouldpass value="Dinner"/>
    /// <shouldfail value="f"/>
    public class MealTimeNameValidator : AbstractValidator<string>
    {
        /// <inheritdoc/>
        public MealTimeNameValidator()
        {
            RuleFor(i => i).NotEmpty().WithMessage(DomainResources.MustNotBeEmpty);
        }
    }
}
