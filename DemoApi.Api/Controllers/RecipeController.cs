using Microsoft.AspNetCore.Mvc;
using MultiValidation;
using DemoApi.Domain.Models;
using DemoApi.DomainServices.Services;
using Microsoft.EntityFrameworkCore;
using DemoApi.Domain.PropertyValidators;

namespace Asp.DemoApi.Api.Controllers
{
    /// <summary>
    /// An example of a controller
    /// </summary>
    [ApiController]
    [Route("/api/v1")]
    public class RecipeController : ControllerBase
    {
        private readonly MultiValidator _validator;
        private readonly RecipeService _recipeService;

        /// <summary>
        /// Constructs an instance of an object
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="recipeService"></param>
        public RecipeController(
            MultiValidator validator,
            RecipeService recipeService)
        {
            _validator = validator;
            _recipeService = recipeService;
        }

        /// <summary>
        /// Gets a recipe by id
        /// </summary>
        /// <param name="id" example="8854">The id of the requested user</param>
        /// <param name="cancellationToken">Optional cancellation token used in the request</param>
        /// <returns>A <see cref="Recipe"/></returns>
        [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet("recipe/{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _validator.For(id).Use<IdValidator>()
                            .ValidateAsync();

            var person = await _recipeService.GetRecipe(id).FirstOrDefaultAsync(cancellationToken);

            return Ok(person);
        }
    }
}
