using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Api.Controllers
{
    //TODO: replace with with proper versioning
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator;
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
