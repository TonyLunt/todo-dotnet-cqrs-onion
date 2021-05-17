using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoLists
{
    public abstract class ToDoListBaseHandler
    {
        protected IRepository<ToDoList> ToDoListRepository;
        protected ILogger<ToDoListBaseHandler> Logger;
        public ToDoListBaseHandler(IRepository<ToDoList> toDoListRepository, ILogger<ToDoListBaseHandler> logger)
        {
            ToDoListRepository = toDoListRepository;
            Logger = logger;
        }
    }
}
