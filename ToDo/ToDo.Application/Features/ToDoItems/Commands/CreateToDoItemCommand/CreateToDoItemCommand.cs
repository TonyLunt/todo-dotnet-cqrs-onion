using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands.CreateToDoItemCommand
{
    public class CreateToDoItemCommand : IRequest<ToDoItemViewModel>
    {
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string Name { get; set; }
        public Guid ToDoListId { get; set; }

        public static explicit operator ToDoItem(CreateToDoItemCommand command)
        {
            return new ToDoItem()
            {
                Name = command.Name,
                ToDoListId = command.ToDoListId,
                IsComplete = false
            };
        }
    }
}
