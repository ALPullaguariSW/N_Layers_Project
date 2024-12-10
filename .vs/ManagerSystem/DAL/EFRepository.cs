using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EFRepository : IRepository
    {
        DbContext _dbContext;

        public EFRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            TEntity result = default;

            try
            {
                var dbSet = _dbContext.Set<TEntity>();
                var entity = toCreate as Entities.Tareas;
                if (entity != null && (dbSet.Local.Any(e => (e as Entities.Tareas).TareaID == entity.TareaID) || dbSet.Any(e => (e as Entities.Tareas).TareaID == entity.TareaID)))
                {
                    throw new InvalidOperationException("El producto ya existe.");
                }

                dbSet.Add(toCreate);
                _dbContext.SaveChanges();
                result = toCreate;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }



        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            bool result = false;
            try
            {
                _dbContext.Entry<TEntity>(toDelete).State = EntityState.Deleted;

                result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> result = null;
            try
            {
                result = _dbContext.Set<TEntity>().Where(criteria).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity result = null;
            try
            {
                result = _dbContext.Set<TEntity>().FirstOrDefault(criteria);

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            bool result = false;
            try
            {
                _dbContext.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
