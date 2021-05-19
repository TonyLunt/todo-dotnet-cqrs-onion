using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDo.IntegrationTests
{
    public class TestResponse<TResponseModel> where TResponseModel : class
    {

        public HttpStatusCode HttpStatusCode { get; set; }
        public TResponseModel ResponseModel { get; set; }
        public bool IsOk { get; set; }
    }
}
