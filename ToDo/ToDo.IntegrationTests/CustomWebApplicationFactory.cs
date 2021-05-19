using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infra.Data;

namespace ToDo.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ToDoContext>));

                services.Remove(descriptor);

                //TODO: Replace this with actual data context eventually
                services.AddDbContext<ToDoContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDatabase");
                });

                var sp = services.BuildServiceProvider();

            });
        }
    }
}
