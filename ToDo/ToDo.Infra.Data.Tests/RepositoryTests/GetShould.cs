using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infra.Data.Tests.RepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.RepositoryTests
{
    public class GetShould : WidgetTestBase
    {
        [Fact]
        public async Task ReturnEntityIfExists()
        {
            var widget = await WidgetFactory.GetExisting();
            var responseWidget = await WidgetRepository.Get(widget.Id);
            Assert.Equal(widget, responseWidget);
        }

        [Fact]
        public async Task ReturnNullIfNotExistsForUser()
        {
            var widget = await SecondaryWidgetFactory.GetExisting();
            var responseWidget = await WidgetRepository.Get(Guid.NewGuid());
            Assert.Null(responseWidget);
        }

        [Fact]
        public async Task ReturnNullIfNotExists()
        {
            var widget = await WidgetFactory.GetExisting();
            var responseWidget = await WidgetRepository.Get(Guid.NewGuid());
            Assert.Null(responseWidget);
        }
    }
}
