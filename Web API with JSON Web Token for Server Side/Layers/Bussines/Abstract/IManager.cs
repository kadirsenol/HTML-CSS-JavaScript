using System.Linq.Expressions;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.DBContexts;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract
{
    public interface IManager<T, TId>
    {
        public IRepository<T, TId, SqlDbContext> _repo { get; } // DBContext degismesi durumunda burasi(3/3) degistirilecek. Burayida DbContext e Managerden erisebilmek adina ekledim.

        //CRUD
        public Task<int> Insert(T entity);
        public Task<int> Update(T entity);
        public Task<int> Delete(T entity);
        public Task<int> DeleteByPK(TId pk);
        public Task<int> DeleteAll(Expression<Func<T, bool>> expression = null);

        //QUERY
        public Task<bool> Any(Expression<Func<T, bool>> expression);
        public Task<T> GetByPK(TId pk);
        public Task<ICollection<T>> GetAll(Expression<Func<T, bool>> expression = null);
        public Task<IEnumerable<T>?> GetAllInclude(Expression<Func<T, bool>>? expression, params Expression<Func<T, object>>[] include);
        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
    }
}
