using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infra.Data.Tests.RepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.RepositoryTests
{
    public class InsertShould : WidgetTestBase
    {
        [Fact]
        public async Task PopulateIdField()
        {
            var widget = WidgetFactory.GetNew();
            var response = await WidgetRepository.Insert(widget);
            Assert.NotEqual(default, response.Id);
        }

        [Fact]
        public async Task PopulateCreatedBy()
        {
            var widget = WidgetFactory.GetNew();
            var response = await WidgetRepository.Insert(widget);
            Assert.Equal(Username, response.CreatedBy);
        }

        [Fact]
        public async Task PopulateCreatedDate()
        {
            var widget = WidgetFactory.GetNew();
            var response = await WidgetRepository.Insert(widget);
            Assert.NotEqual(default, response.CreatedDate);
        }

        [Fact]
        public async Task PopulateUpdatedBy()
        {
            var widget = WidgetFactory.GetNew();
            var response = await WidgetRepository.Insert(widget);
            Assert.Equal(Username, response.UpdatedBy);
        }

        [Fact]
        public async Task PopulateUpdatedDate()
        {
            var widget = WidgetFactory.GetNew();
            var response = await WidgetRepository.Insert(widget);
            Assert.NotEqual(default, response.UpdatedDate);
        }
    }
}
