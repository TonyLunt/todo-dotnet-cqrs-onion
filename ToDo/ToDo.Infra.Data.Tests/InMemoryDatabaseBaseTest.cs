using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infra.Data.Tests
{
    public class InMemoryDatabaseBaseTest<TContext> : IDisposable where TContext : DbContext
    {
        private readonly DbConnection _connection;
        protected readonly TContext DataContext;

        public InMemoryDatabaseBaseTest()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<TContext>()
                .UseSqlite(_connection)
                .Options;

            DataContext = (TContext)Activator.CreateInstance(typeof(TContext), options);

            DataContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
