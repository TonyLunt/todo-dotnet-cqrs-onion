using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;
using ToDo.Infra.Data.Repositories;

namespace ToDo.Infra.Data.Tests.ToDoItemRepositoryTests.Setup
{
    public class ToDoItemTestBase : InMemoryDatabaseBaseTest<ToDoContext>
    {
        protected ToDoListFactory ToDoListFactory;
        protected ToDoItemRepository ToDoItemRepository;
        protected string Username;
        public ToDoItemTestBase()
        {
            Username = Guid.NewGuid().ToString();
            ToDoListFactory = new ToDoListFactory(DataContext);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetUserName()).Returns(Username);
            ToDoItemRepository = new ToDoItemRepository(DataContext, mockUserService.Object);
        }
    }
}

