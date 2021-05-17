using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Tests
{
    public static class StaticTestHelpers
    {
        public static List<ValidationResult> GetValidationResults(object entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, results, true);
            return results;
        }

        public static string GetRandomString(int length)
        {
            var returnVal = string.Empty;
            while (returnVal.Length < length)
            {
                returnVal += Guid.NewGuid().ToString();
            }
            return returnVal.Substring(0, length);
        }
    }
}
