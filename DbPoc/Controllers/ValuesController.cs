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
    public class ValuesController : ControllerBase
    {
        private readonly SystemTime systemTime;
        private readonly IMediator mediator;

        public ValuesController(IMediator mediator,SystemTime systemTime)
        {
            this.mediator = mediator;
            this.systemTime = systemTime;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> result = await mediator.Send(new GetAllProductQuery());
            return result.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value {systemTime.Now}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
