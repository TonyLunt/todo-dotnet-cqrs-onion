using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Commands.RenameToDoListCommand;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.RenameToDoListCommandTests
{
    public class RenameToDoListCommandValidationShould
    {
        [Fact]
        public void ReturnValidIfModelValid()
        {
            var model = GetValidModel();
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ReturnInvalidIfNameTooLong()
        {
            var model = GetValidModel();
            model.Name = StaticTestHelpers.GetRandomString(1000);
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Contains(validationResults, validationResult => validationResult.MemberNames.Contains("Name") && validationResult.ErrorMessage.ToLower().Contains("max"));
        }

        [Fact]
        public void ReturnInvalidIfNameTooShort()
        {
            var model = GetValidModel();
            model.Name = StaticTestHelpers.GetRandomString(2);
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Contains(validationResults, validationResult => validationResult.MemberNames.Contains("Name") && validationResult.ErrorMessage.ToLower().Contains("min"));
        }


        [Fact]
        public void ReturnInvalidIfNameMissing()
        {
            var model = GetValidModel();
            model.Name = null;
            var validationResults = StaticTestHelpers.GetValidationResults(model);
            Assert.Contains(validationResults, validationResult => validationResult.MemberNames.Contains("Name") && validationResult.ErrorMessage.ToLower().Contains("required"));
        }

        private RenameToDoListCommand GetValidModel()
        {
            return new RenameToDoListCommand()
            {
                Name = "Foo Name",
                Id = Guid.NewGuid()
            };
        }
    }
}
