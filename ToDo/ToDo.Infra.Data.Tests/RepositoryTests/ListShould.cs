using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infra.Data.Tests.RepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.RepositoryTests
{
    public class ListShould : WidgetTestBase
    {
        [Fact]
        public async Task ReturnAll()
        {
            var count = 4;
            var expectedWidgets = new List<Widget>();
            for (int i = 0; i < count; i++)
            {
                expectedWidgets.Add(await WidgetFactory.GetExisting());
            }

            var responseWidgets = await WidgetRepository.List();
            Assert.All(expectedWidgets, expectedWidget => Assert.Contains(responseWidgets, responseWidget => expectedWidget.Id == responseWidget.Id));
        }

        [Fact]
        public async Task ReturnEmptyListIfNoneExists()
        {
            DataContext.Widgets.RemoveRange(DataContext.Widgets);
            await DataContext.SaveChangesAsync();
            var responseWidgets = await WidgetRepository.List();
            Assert.Empty(responseWidgets);
        }
    }
}
