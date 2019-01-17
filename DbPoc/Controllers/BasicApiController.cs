using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DbPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasicApiController:ControllerBase
    {
        protected readonly IMediator mediator;

        public BasicApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}