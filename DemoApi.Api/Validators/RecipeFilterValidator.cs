using DemoApi.Api.Filters;
using DemoApi.Domain.PropertyValidators;
using FluentValidation;

namespace DemoApi.Api.Validators
{
    /// <summary>
    /// Validator for a <see cref="RecipeFilter"/>
    /// </summary>
    public class RecipeFilterValidator : AbstractValidator<RecipeFilter>
    {
        /// <summary>
        /// Constructs an instance of an object
        /// </summary>
        /// <param name="mealTimeValidator"></param>
        public RecipeFilterValidator(MealTimeNameValidator mealTimeValidator)
        {
            RuleFor(f => f.MealTime).SetValidator(mealTimeValidator).When(r => r.MealTime != null);
        }
    }
}
