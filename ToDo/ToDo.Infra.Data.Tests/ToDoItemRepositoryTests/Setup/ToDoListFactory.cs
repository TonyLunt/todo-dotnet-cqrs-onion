using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.Tests.ToDoItemRepositoryTests.Setup
{
    public class ToDoListFactory
    {
        private ToDoContext _context;
        private UserAuthContext _authContext;
        public ToDoListFactory(ToDoContext context, UserAuthContext userAuthContext)
        {
            _context = context;
            _authContext = userAuthContext;
        }

        public async Task<ToDoList> GetPopulatedToDoList()
        {
            var toDoItems = new List<ToDoItem>();
            for (int i = 0; i < 3; i++)
            {
                toDoItems.Add(new ToDoItem()
                {
                    UserId = _authContext.UniqueIdentifier,
                    UpdatedBy = Guid.NewGuid().ToString(),
                    CreatedBy = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsComplete = false,
                    Name = Guid.NewGuid().ToString()
                });
            }
            var toDoList = new ToDoList()
            {
                UserId = _authContext.UniqueIdentifier,
                UpdatedBy = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                ToDoItems = toDoItems
            };
            _context.Add(toDoList);
            await _context.SaveChangesAsync();
            return toDoList;
        }
    }
}
