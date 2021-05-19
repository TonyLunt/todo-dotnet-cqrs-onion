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
using ToDo.Application.Features.ToDoItems.Queries.GetToDoItemsForListQuery;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Api.Controllers
{
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemViewModel>>> GetToDoItems([FromQuery] Guid toDoListId)
        {
            var response = await Mediator.Send(new GetToDoItemsForListQuery() { Id = toDoListId }, new System.Threading.CancellationToken());
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
        [Route("Status")]
        public async Task<ActionResult<ToDoItemViewModel>> UpdateStatus(UpdateToDoItemStatusCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ToDoItemViewModel>> Delete([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new DeleteToDoItemCommand() { Id = id }, new System.Threading.CancellationToken());
            return Ok(response);
        }
    }
}
