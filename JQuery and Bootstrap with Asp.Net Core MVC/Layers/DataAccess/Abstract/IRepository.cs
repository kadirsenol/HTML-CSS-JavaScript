using System.Linq.Expressions;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Abstract
{
    public interface IRepository<T, TId>
    {
        public Task<int> Insert(T entity);
        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression = null);
        public Task<bool> Any(Expression<Func<T, bool>> expression);

        public Task<int> DeleteById(TId id);
        public Task<T> GetById(TId id);

        public Task<int> Update(T entity);

    }
}
