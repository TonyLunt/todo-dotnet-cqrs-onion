using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems
{
    public class ToDoItemBaseHandler
    {
        protected IToDoItemRepository ToDoItemRepository;
        protected ILogger<ToDoItemBaseHandler> Logger;

        public ToDoItemBaseHandler(IToDoItemRepository toDoItemRepository, ILogger<ToDoItemBaseHandler> logger)
        {
            ToDoItemRepository = toDoItemRepository;
            Logger = logger;
        }
    }
}
