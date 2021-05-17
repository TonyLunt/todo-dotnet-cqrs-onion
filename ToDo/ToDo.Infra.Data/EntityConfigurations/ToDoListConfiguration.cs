using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EntityConfigurations
{
    public class ToDoListConfiguration : BaseEntityConfiguration<ToDoList>
    {
        public override void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(500);

            builder
                .HasMany(x => x.ToDoItems)
                .WithOne(x => x.ToDoList)
                .HasForeignKey(x => x.ToDoListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
