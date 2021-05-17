using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;
using ToDo.Domain.Common;
using ToDo.Domain.Entities;
using ToDo.Infra.Data.EntityConfigurations;

namespace ToDo.Infra.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ToDoListConfiguration().Configure(builder.Entity<ToDoList>());
            new ToDoItemConfiguration().Configure(builder.Entity<ToDoItem>());

            base.OnModelCreating(builder);
        }
    }
}
