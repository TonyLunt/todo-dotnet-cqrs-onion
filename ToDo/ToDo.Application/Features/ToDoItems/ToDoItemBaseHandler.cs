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
        protected IRepository<ToDoItem> ToDoItemRepository;
        protected IRepository<ToDoList> ToDoListRepository;

        protected ILogger<ToDoItemBaseHandler> Logger;
        public ToDoItemBaseHandler(IRepository<ToDoItem> toDoItemRepository, IRepository<ToDoList> toDoListRepository, ILogger<ToDoItemBaseHandler> logger)
        {
            ToDoItemRepository = toDoItemRepository;
            ToDoListRepository = toDoListRepository;
            Logger = logger;
        }
    }
}
