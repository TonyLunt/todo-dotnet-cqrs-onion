using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class WidgetFactory
    {
        private TestContext _context;

        public WidgetFactory(TestContext context)
        {
            _context = context;
        }

        public Widget GetNew()
        {
            return new Widget()
            {
                Name = Guid.NewGuid().ToString()
            };
        }

        public async Task<Widget> GetExisting() 
        {
            var widget = new Widget()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now.AddDays(-5),
                UpdatedDate = DateTime.Now.AddDays(-5)
            };
            _context.Widgets.Add(widget);
            await _context.SaveChangesAsync();
            return widget;
        }
    }
}
