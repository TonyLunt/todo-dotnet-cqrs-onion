using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Common;

namespace ToDo.Infra.Data.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //Note the lack of configuration for the ID property.
            //EF should be smart enough to sort this out by naming convention.

            builder
                .Property(x => x.CreatedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.UpdatedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.CreatedDate)
                .IsRequired();

            builder
                .Property(x => x.UpdatedDate)
                .IsRequired();

        }
    }
}
