using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.Concrete
{
    public class Repository<T, TId, TDbContext> : IRepository<T, TId, TDbContext> where T : BaseEntity<TId> where TDbContext : DbContext, new()
    {
        public TDbContext dbContext { get; }
        public Repository() //TDbContext dbcon
        {
            dbContext = new TDbContext();
            //dbContext = dbcon;
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

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().AnyAsync(expression);
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

