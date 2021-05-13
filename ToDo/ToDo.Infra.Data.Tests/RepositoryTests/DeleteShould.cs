using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task ThrowExceptionIfNotExists()
        {
            await Assert.ThrowsAnyAsync<Exception>(async () => await WidgetRepository.Delete(Guid.NewGuid()));
        }
    }
}
