using DemoApi.Domain.Resources;
using FluentValidation;

namespace DemoApi.Domain.PropertyValidators
{
    /// <summary>
    /// Validates an Id
    /// </summary>
    /// <shouldpass value="87554"/>
    /// <shouldfail value="0"/>
    /// <shouldfail value="-1"/>
    public class IdValidator : AbstractValidator<int>
    {
        /// <inheritdoc/>
        public IdValidator()
        {
            RuleFor(i => i).GreaterThan(0).WithMessage(DomainResources.MustBeGreaterThanZero);
        }
    }
}
