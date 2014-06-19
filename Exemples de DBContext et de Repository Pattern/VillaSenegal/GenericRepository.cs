using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSenegalDAL
{
    public  class GenericRepository <T> : IRepository<T> where T : class
    {

        protected DbSet<T> DBset { get; set;  }
        protected DbContext Context { get; set;  }

        public GenericRepository(DbContext context)
        {
            
                if (context == null)
                {
                    throw new ArgumentException("An instan,ce of DbContext is " + "required to uses this repository.", "context");

                }

                this.Context = context;

                this.DBset = this.Context.Set<T>();
           

        }

        public IQueryable<T> GetAll()
        {
            return this.DBset;

        }

        public T GetById(int id)
        {
            return this.DBset.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if(entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }

            else
            {
                this.DBset.Add(entity);
            }
            
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DBset.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DBset.Attach(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if(entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }
    }
}
