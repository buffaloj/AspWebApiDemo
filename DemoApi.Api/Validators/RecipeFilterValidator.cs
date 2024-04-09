using DemoApi.Api.Filters;
using DemoApi.Domain.PropertyValidators;
using FluentValidation;

namespace DemoApi.Api.Validators
{
    public class RecipeFilterValidator : AbstractValidator<RecipeFilter>
    {
        public RecipeFilterValidator(MealTimeNameValidator mealTimeValidator)
        {
            RuleFor(f => f.MealTime).SetValidator(mealTimeValidator).When(r => r.MealTime != null);
        }
    }
}
