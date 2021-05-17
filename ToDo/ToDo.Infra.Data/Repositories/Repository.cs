using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Repositories;
using ToDo.Application.Services.UserService;
using ToDo.Domain.Common;

namespace ToDo.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext Context;

        protected UserAuthContext AuthContext;

        public Repository(DbContext context, IUserService userService)
        {
            Context = context;
            AuthContext = userService.GetUserAuthContext();
            
        }

        protected IQueryable<TEntity> Queryable
        {
            get
            {
                return Context.Set<TEntity>().Where(x => x.UserId == AuthContext.UniqueIdentifier);
            }
        }

        public async Task Delete(Guid id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                throw new NotFoundException(id, typeof(TEntity));
            }
            Context.Set<TEntity>().Remove(entity);
            await Save();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Save();
            return entity;
        }

        public async Task<List<TEntity>> List()
        {
            return await Queryable.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var dbEntity = await Get(entity.Id);
            if (dbEntity == null)
            {
                throw new NotFoundException(entity.Id, typeof(TEntity));
            }
            Context.Set<TEntity>().Update(entity);
            await Save();
            return entity;
        }

        private async Task Save()
        {
            foreach (var baseEntity in Context.ChangeTracker.Entries<BaseEntity>())
            {
                if (baseEntity.State == EntityState.Added)
                {
                    baseEntity.Entity.Id = Guid.NewGuid();
                    baseEntity.Entity.UserId = AuthContext.UniqueIdentifier;
                    baseEntity.Entity.CreatedBy = AuthContext.UserName;
                    baseEntity.Entity.CreatedDate = DateTime.UtcNow;
                }

                if (baseEntity.State == EntityState.Added
                    || baseEntity.State == EntityState.Modified)
                {
                    baseEntity.Entity.UpdatedBy = AuthContext.UserName;
                    baseEntity.Entity.UpdatedDate = DateTime.UtcNow;

                    //These properties only settable at insertion time
                    Context.Entry(baseEntity.Entity).Property(x => x.CreatedBy).IsModified = false;
                    Context.Entry(baseEntity.Entity).Property(x => x.CreatedDate).IsModified = false;
                    Context.Entry(baseEntity.Entity).Property(x => x.UserId).IsModified = false;
                }
            }

            await Context.SaveChangesAsync();
        }
    }
}
