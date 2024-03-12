using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.DataAccess.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.DataAccess.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Concrete
{
    public class Manager<T, TId, TDbContext> : IManager<T, TId> where T : BaseEntity<TId> where TDbContext : DbContext, new()
    {
        IRepository<T, TId> _repo;
        public Manager()
        {
            _repo = new Repository<T, TId, TDbContext>();
        }

        public virtual async Task<int> Delete(T entity)
        {
            return await _repo.Delete(entity);
        }

        public virtual async Task<int> DeleteAll(Expression<Func<T, bool>> expression = null)
        {
            return await _repo.DeleteAll(expression);
        }

        public virtual async Task<int> DeleteByPK(TId pk)
        {
            return await _repo.DeleteByPK(pk);
        }

        public virtual async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return await _repo.GetAll(expression);
        }

        public virtual async Task<IEnumerable<T>?> GetAllInclude(Expression<Func<T, bool>>? expression, params Expression<Func<T, object>>[] include)
        {
            return await _repo.GetAllInclude(expression, include);
        }

        public virtual async Task<T> GetByPK(TId pk)
        {
            return await _repo.GetByPK(pk);
        }

        public virtual async Task<int> Insert(T entity)
        {
            return await _repo.Insert(entity);
        }

        public virtual async Task<int> Update(T entity)
        {
            return await _repo.Update(entity);
        }

        public async virtual Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return await _repo.FirstOrDefault(expression);
        }
    }
}
