using DbPoc.Application.Commands.Products;
using DbPoc.Application.Queries.Products;
using DbPoc.Binders;
using DbPoc.Common;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DbPoc.Controllers
{
    public class ProductApiController : BasicApiController
    {
        private readonly ISystemTime systemTime;

        public ProductApiController(IMediator mediator, ISystemTime systemTime):base(mediator)
        {
            this.systemTime = systemTime;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> result = await mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByTime(
            [ModelBinder(BinderType =typeof(DateTimeBinders))]
        DateTime? stateTime)
        {
            IEnumerable<Product> result = await mediator.Send(new GetAllProductByTimeQuery
            {
                StateTime = stateTime ?? DateTime.UtcNow
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Product>>> GetWithRecipeByTime(
          [ModelBinder(BinderType =typeof(DateTimeBinders))]
        DateTime? stateTime)
        {
            IEnumerable<Product> result = await mediator.Send(new GetAllProductWithRecipeByTimeQuery
            {
                StateTime = stateTime ?? DateTime.UtcNow
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await mediator.Send(new GetProductQuery { Id = id });
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateProductCommand command)
        {
            int id = await mediator.Send(command);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
