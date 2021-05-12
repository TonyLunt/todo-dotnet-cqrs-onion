using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EntityConfigurations
{
    public class ToDoItemConfiguration : BaseEntityConfiguration<ToDoItem>
    {
        public override void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

        }
    }
}
