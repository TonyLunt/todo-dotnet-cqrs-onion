using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommandTests
{
    public class UpdateToDoListDescriptionCommandValidationShould
    {
        [Fact]
        public void ReturnValidIfModelValid()
        {
            var model = GetValidModel();
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ReturnInvalidIfDescriptionTooLong()
        {
            var model = GetValidModel();
            model.Description = StaticTestHelpers.GetRandomString(1000);
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Contains(validationResults, validationResult => validationResult.MemberNames.Contains("Description") && validationResult.ErrorMessage.ToLower().Contains("max"));
        }

        [Fact]
        public void ReturnValidIfDescriptionNull()
        {
            var model = GetValidModel();
            model.Description = null;
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ReturnValidIfDescriptionEmpty()
        {
            var model = GetValidModel();
            model.Description = String.Empty;
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Empty(validationResults);
        }

        private UpdateToDoListDescriptionCommand GetValidModel()
        {
            return new UpdateToDoListDescriptionCommand()
            {
                Description = "Foo Name",
                Id = Guid.NewGuid()
            };
        }
    }
}
