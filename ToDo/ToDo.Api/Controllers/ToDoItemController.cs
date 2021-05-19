using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.Commands.CreateToDoItemCommand;
using ToDo.Application.Features.ToDoItems.Commands.DeleteToDoItemCommand;
using ToDo.Application.Features.ToDoItems.Commands.RenameToDoItemCommand;
using ToDo.Application.Features.ToDoItems.Commands.UpdateToDoItemStatusCommand;
using ToDo.Application.Features.ToDoItems.Queries.GetToDoItemQuery;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : BaseController
    {
        public ToDoItemController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> Get([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new GetToDoItemQuery() { Id = id }, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemViewModel>> Create(CreateToDoItemCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPut]
        [Route("Name")]
        public async Task<ActionResult<ToDoItemViewModel>> Rename(RenameToDoItemCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPut]
        [Route("Description")]
        public async Task<ActionResult<ToDoItemViewModel>> UpdateStatus(UpdateToDoItemStatusCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ToDoItemViewModel>> Delete(DeleteToDoItemCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }
    }
}
