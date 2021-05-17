using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Application.Services.UserService;
using ToDo.Infra.Data.Repositories;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class WidgetTestBase : InMemoryDatabaseBaseTest<TestContext>
    {
        protected WidgetFactory WidgetFactory;
        protected IRepository<Widget> WidgetRepository;
        protected UserAuthContext AuthContext;
        public WidgetTestBase() 
        {
            AuthContext = new UserAuthContext()
            {
                IsAuthenticated = true,
                UniqueIdentifier = Guid.NewGuid(),
                UserName = Guid.NewGuid().ToString()
            };
            WidgetFactory = new WidgetFactory(DataContext);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetUserAuthContext()).Returns(AuthContext);
            WidgetRepository = new Repository<Widget>(DataContext, mockUserService.Object);
        }
    }
}
