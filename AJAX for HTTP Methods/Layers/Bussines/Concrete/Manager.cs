﻿using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.DataAccess.Abstract;
using AJAX_for_HTTP_Methods.Layers.DataAccess.Concrete;
using AJAX_for_HTTP_Methods.Layers.DataAccess.DBContexts;
using AJAX_for_HTTP_Methods.Layers.Entities.Abstract;
using System.Linq.Expressions;

namespace AJAX_for_HTTP_Methods.Layers.Bussines.Concrete
{
    public class Manager<T, TId> : IManager<T, TId> where T : BaseEntity<TId>
    {

        public IRepository<T, TId, SqlDbContext> _repo { get; } // DBContext degismesi durumunda burasi(1/3) degistirilecek. Bussines layer de kompleks is kurallari ve api projesinde ki put isleminde dbcontexte ihtiyac duydugum icin IManagere ekledigim dbcontext.
                                                                // DbContext ctordan istendiginde degismesi halinde herbir manager sinifi icin degistirilmesi gerekecek. Ama bu sekilde sadece yerden degismesi yetiyor.

        public Manager() //SqlDbContext dbContext
        {
            _repo = new Repository<T, TId, SqlDbContext>(); // DBContext degismesi durumunda burasi(2/3) degistirilecek.
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
        public async virtual Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _repo.Any(expression);
        }
    }
}
