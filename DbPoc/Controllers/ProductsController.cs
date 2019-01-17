using DbPoc.Application.Commands.Products;
using DbPoc.Application.Queries.Products;
using DbPoc.Binders;
using DbPoc.Common;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DbPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISystemTime systemTime;
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator, ISystemTime systemTime)
        {
            this.mediator = mediator;
            this.systemTime = systemTime;
        }

        // GET api/values
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

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await mediator.Send(new GetProductQuery { Id = id });
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateProductCommand command)
        {
            int id = await mediator.Send(command);

            return Ok(id);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
