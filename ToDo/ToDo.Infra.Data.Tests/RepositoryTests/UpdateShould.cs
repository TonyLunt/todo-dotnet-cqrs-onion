using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Infra.Data.Tests.RepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.RepositoryTests
{
    public class UpdateShould : WidgetTestBase
    {
        [Fact]
        public async Task UpdateRecordInDatabase()
        {
            var expectedName = Guid.NewGuid().ToString();
            var widget = await WidgetFactory.GetExisting();
            widget.Name = expectedName;
            var response = await WidgetRepository.Update(widget);
            Assert.Equal(expectedName, response.Name);
        }

        [Fact]
        public async Task ThrowExceptionIfForOtherUser()
        {
            var widget = await SecondaryWidgetFactory.GetExisting();
            await Assert.ThrowsAsync<NotFoundException>(async() => await WidgetRepository.Update(widget));
        }

        [Fact]
        public async Task PopulateUpdatedBy()
        {
            var widget = await WidgetFactory.GetExisting();
            var response = await WidgetRepository.Update(widget);
            Assert.Equal(AuthContext.UserName, response.UpdatedBy);
        }

        [Fact]
        public async Task PopulateUpdatedDate()
        {
            var widget = await WidgetFactory.GetExisting();
            var originalUpdatedDate = widget.UpdatedDate;
            var response = await WidgetRepository.Update(widget);
            Assert.NotEqual(originalUpdatedDate, response.UpdatedDate);
        }

        [Fact]
        public async Task NotPopulateCreatedBy()
        {
            var widget = await WidgetFactory.GetExisting();
            var originalCreatedBy = widget.CreatedBy;
            var response = await WidgetRepository.Update(widget);
            Assert.Equal(originalCreatedBy, response.CreatedBy);
        }

        [Fact]
        public async Task NotPopulateCreatedDate()
        {
            var widget = await WidgetFactory.GetExisting();
            var originalCreatedDate = widget.CreatedDate;
            var response = await WidgetRepository.Update(widget);
            Assert.Equal(originalCreatedDate, response.CreatedDate);
        }
    }
}
