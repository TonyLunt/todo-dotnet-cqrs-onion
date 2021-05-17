using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infra.Data.Tests.ToDoItemRepositoryTests.Setup;
using Xunit;

namespace ToDo.Infra.Data.Tests.ToDoItemRepositoryTests
{
    public class GetForListShould : ToDoItemTestBase
    {
        [Fact]
        public async Task ReturnAllToDoItemsForList()
        {
            for (int i = 0; i < 3; i++)
            {
                //seeding unrelated data to ensure it does not get returned
                await ToDoListFactory.GetPopulatedToDoList();
            }
            var toDoList = await ToDoListFactory.GetPopulatedToDoList();
            var toDoItems = await ToDoItemRepository.GetForList(toDoList.Id);
            Assert.All(toDoItems, toDoItem => 
                Assert.Contains(toDoList.ToDoItems, listItem => 
                    listItem.Name == toDoItem.Name
                    )
                );
        }

    }
}
