using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;

namespace ToDo.Domain.Entities
{
    public class ToDoList : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
