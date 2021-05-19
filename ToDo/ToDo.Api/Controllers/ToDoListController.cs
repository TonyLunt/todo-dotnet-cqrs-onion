using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.Queries.GetToDoItemsForListQuery;
using ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand;
using ToDo.Application.Features.ToDoLists.Commands.DeleteToDoListCommand;
using ToDo.Application.Features.ToDoLists.Commands.RenameToDoListCommand;
using ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand;
using ToDo.Application.Features.ToDoLists.Queries.GetToDoListQuery;
using ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Api.Controllers
{
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<ToDoListViewModel>>> Get([FromRoute]Guid id)
        {
            var response = await Mediator.Send(new GetToDoListQuery() { Id = id }, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoListViewModel>> Create(CreateToDoListCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPut]
        [Route("Name")]
        public async Task<ActionResult<ToDoListViewModel>> Rename(RenameToDoListCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpPut]
        [Route("Description")]
        public async Task<ActionResult<ToDoListViewModel>> UpdateDescription(UpdateToDoListDescriptionCommand command)
        {
            var response = await Mediator.Send(command, new System.Threading.CancellationToken());
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ToDoListViewModel>> DeleteToDoList([FromRoute]Guid id)
        {
            var response = await Mediator.Send(new DeleteToDoListCommand() { Id = id }, new System.Threading.CancellationToken());
            return Ok(response);
        }

    }
}
