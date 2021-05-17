using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems;
using ToDo.Application.Repositories;
using ToDo.Infra.Data.Repositories;

namespace ToDo.Infra.Data
{
    public static class ServiceConfigurationExtensions
    {
        public static void AddInfraDataLayer(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
            });
            services.AddScoped<DbContext, ToDoContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IToDoItemRepository, ToDoItemRepository>();
        }
    }
}
