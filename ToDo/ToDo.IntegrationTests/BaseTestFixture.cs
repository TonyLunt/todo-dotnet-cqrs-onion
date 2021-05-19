using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDo.IntegrationTests
{
    public class BaseTestFixture
    {
        protected TEntity JsonDeserialize<TEntity>(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var responseModel = JsonSerializer.Deserialize<TEntity>(json, options);
            return responseModel;
        }
    }
}
