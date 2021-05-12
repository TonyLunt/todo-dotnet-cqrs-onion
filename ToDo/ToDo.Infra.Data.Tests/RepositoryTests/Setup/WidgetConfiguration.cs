using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;
using ToDo.Domain.Entities;
using ToDo.Infra.Data.EntityConfigurations;

namespace ToDo.Infra.Data.Tests.RepositoryTests.Setup
{
    class WidgetConfiguration : BaseEntityConfiguration<Widget>
    {
        public override void Configure(EntityTypeBuilder<Widget> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}