using DbPoc.Application.Commands.Recipes;
using DbPoc.Application.Queries.Recipes;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DbPoc.Controllers
{
    public class RecipeApiController : BasicApiController
    {
        public RecipeApiController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> Get()
        {
            IEnumerable<Recipe> recipes = await mediator.Send(new GetAllRecipeQuery());
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateRecipeCommand command)
        {
            int id = await mediator.Send(command);

            return Ok(id);
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateRecipeCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteRecipeCommand { Id = id });
            return NoContent();
        }

    }
}
