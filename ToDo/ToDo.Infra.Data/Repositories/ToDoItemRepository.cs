using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems;
using ToDo.Application.Services.UserService;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(DbContext context, IUserService userService) : base(context, userService)
        {

        }

        public async Task<List<ToDoItem>> GetForList(Guid id)
        {
            var toDoItems = await Queryable.Where(x => x.ToDoListId == id).ToListAsync();
            return toDoItems;
        }
    }
}
