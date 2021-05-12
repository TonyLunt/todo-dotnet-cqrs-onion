using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class Widget : BaseEntity
    {
        public string Name { get; set; }
    }
}
