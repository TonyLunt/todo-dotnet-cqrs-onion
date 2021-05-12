using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Application.Services;
using ToDo.Infra.Data.Repositories;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class WidgetTestBase : InMemoryDatabaseBaseTest<TestContext>
    {
        protected WidgetFactory WidgetFactory;
        protected IRepository<Widget> WidgetRepository;
        protected string Username;
        public WidgetTestBase() 
        {
            Username = Guid.NewGuid().ToString();
            WidgetFactory = new WidgetFactory(DataContext);
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetUserName()).Returns(Username);
            WidgetRepository = new Repository<Widget>(DataContext, mockUserService.Object);
        }
    }
}
