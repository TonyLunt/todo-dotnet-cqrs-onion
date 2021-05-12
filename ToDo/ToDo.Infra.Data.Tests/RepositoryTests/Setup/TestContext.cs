using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class TestContext : DbContext
    {
        public DbSet<Widget> Widgets { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new WidgetConfiguration().Configure(builder.Entity<Widget>());

            base.OnModelCreating(builder);
        }
    }
}
