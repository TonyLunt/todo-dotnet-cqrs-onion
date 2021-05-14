using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;

namespace ToDo.Domain.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public Guid ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
