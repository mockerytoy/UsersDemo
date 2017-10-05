using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model.Contracts;

namespace Users.Repository.Repositories
{
    public class EfRepository<T> : IEfRepository<T>
        where T : class, IDeletable
    {
        private readonly UsersDbContext _context;
        public EfRepository(UsersDbContext context)
        {
            this._context = context;
        }
        public IQueryable<T> All
        {
            get
            {
                return this._context.Set<T>().Where(e => !e.IsDeleted);
            }
        }


        public IQueryable<T> AllWithDeleted
        {
            get
            {
                return this._context.Set<T>();
            }
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this._context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this._context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this._context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this._context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
