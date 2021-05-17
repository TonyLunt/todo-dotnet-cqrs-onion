using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;

namespace ToDo.Application.Common.ViewModels
{
    public abstract class BaseEntityViewModel
    {
        public BaseEntityViewModel()
        {

        }

        public BaseEntityViewModel(BaseEntity entity)
        {
            Id = entity.Id;
            CreatedBy = entity.CreatedBy;
            UpdatedBy = entity.UpdatedBy;
            CreatedDate = entity.CreatedDate;
            UpdatedDate = entity.UpdatedDate;
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
