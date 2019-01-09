using DbPoc.Application.Commands.Products;
using DbPoc.Application.Queries.Products;
using DbPoc.Common;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value {systemTime.Now}";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateProductCommand command)
        {
            int id = await mediator.Send(command);

            return Ok(id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
