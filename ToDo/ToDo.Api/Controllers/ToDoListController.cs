using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : BaseController
    {
        public ToDoListController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListViewModel>>> Get()
        {
            var response = await Mediator.Send(new ListToDoListQuery(), new System.Threading.CancellationToken());
            return Ok(response);
        }
    }
}
