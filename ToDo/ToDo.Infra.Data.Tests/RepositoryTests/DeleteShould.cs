using System;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Infra.Data.Tests.RepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.RepositoryTests
{
    public class DeleteShould : WidgetTestBase
    {
        [Fact]
        public async Task RemoveRecordFromDatabase()
        {
            var widget = await WidgetFactory.GetExisting();
            await WidgetRepository.Delete(widget.Id);
            var dbWidget = await DataContext.Widgets.FindAsync(widget.Id);
            Assert.Null(dbWidget);
        }

        [Fact]
        public async Task ThrowExceptionIfForOtherUser()
        {
            var widget = await SecondaryWidgetFactory.GetExisting();
            await Assert.ThrowsAsync<NotFoundException>(async () => await WidgetRepository.Delete(widget.Id));
        }

        [Fact]
        public async Task ThrowExceptionIfNotExists()
        {
            await Assert.ThrowsAnyAsync<Exception>(async () => await WidgetRepository.Delete(Guid.NewGuid()));
        }
    }
}
