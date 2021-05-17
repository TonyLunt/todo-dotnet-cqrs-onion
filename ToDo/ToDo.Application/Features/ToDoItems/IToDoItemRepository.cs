using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems
{
    public interface IToDoItemRepository : IRepository<ToDoItem>
    {
        Task<List<ToDoItem>> GetForList(Guid id);
    }
}
