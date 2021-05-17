using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid id, Type type) : base($"Entity of type '{type.Name}' with ID '{id}' not found") { }
    }
}
