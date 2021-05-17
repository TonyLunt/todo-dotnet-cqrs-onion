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
        protected UserAuthContext AuthContext;
        public ToDoItemTestBase()
        {
            AuthContext = new UserAuthContext()
            {
                IsAuthenticated = true,
                UniqueIdentifier = Guid.NewGuid(),
                UserName = Guid.NewGuid().ToString()
            };
            Username = Guid.NewGuid().ToString();
            ToDoListFactory = new ToDoListFactory(DataContext, AuthContext);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetUserAuthContext()).Returns(AuthContext);
            ToDoItemRepository = new ToDoItemRepository(DataContext, mockUserService.Object);
        }
    }
}

