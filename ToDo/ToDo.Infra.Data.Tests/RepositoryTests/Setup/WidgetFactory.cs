using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    public class WidgetFactory
    {
        private TestContext _context;
        private UserAuthContext _authContext;

        public WidgetFactory(TestContext context, UserAuthContext userAuthContext)
        {
            _context = context;
            _authContext = userAuthContext;
        }

        public Widget GetNew()
        {
            return new Widget()
            {
                Name = Guid.NewGuid().ToString()
            };
        }

        public async Task<Widget> GetExisting(Guid? userId = null) 
        {
            userId = userId ?? _authContext.UniqueIdentifier;
            var widget = new Widget()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedBy = Guid.NewGuid().ToString(),
                UpdatedBy = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now.AddDays(-5),
                UpdatedDate = DateTime.Now.AddDays(-5),
                UserId = userId.Value
            };
            _context.Widgets.Add(widget);
            await _context.SaveChangesAsync();
            return widget;
        }
    }
}
