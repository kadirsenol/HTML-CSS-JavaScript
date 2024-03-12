using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.DataAccess.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.DataAccess.Concrete
{
    public class Repository<T, TId, TDbContext> : IRepository<T, TId> where T : BaseEntity<TId> where TDbContext : DbContext, new()
    {
        private readonly TDbContext dbContext;
        public Repository()
        {
            dbContext = new TDbContext();
        }
        public async Task<int> Insert(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAll(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> findentities = await dbContext.Set<T>().Where(expression).ToListAsync();
            dbContext.Set<T>().RemoveRange(findentities);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteByPK(TId pk)
        {
            T findentity = await dbContext.Set<T>().FindAsync(pk);
            dbContext.Set<T>().Remove(findentity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                return await dbContext.Set<T>().Where(expression).ToListAsync();
            }
            else
            {
                return await dbContext.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetByPK(TId pk)
        {
            return await dbContext.Set<T>().FindAsync(pk);
        }

        public async Task<IEnumerable<T>?> GetAllInclude(Expression<Func<T, bool>>? expression, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query;
            if (expression != null)
            {
                query = dbContext.Set<T>().Where(expression);
            }
            else
            {
                query = dbContext.Set<T>();
            }

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

    }

}

