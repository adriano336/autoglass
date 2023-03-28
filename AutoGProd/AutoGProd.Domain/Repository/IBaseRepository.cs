using AutoGProd.Domain.Entity;
using System.Linq.Expressions;

namespace AutoGProd.Domain.Repository
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> Create(T entity);
        Task<T> FindById(long id);
        Task<List<T>> FindAll();
        Task<T> Update(T entity);
        Task Delete(long id);
        Task<bool> Exists(long? id);
        Task<List<T>> FindWithPagedSearch(Func<T, bool> query, int start, int total);
        Task<int> GetCount(Expression<Func<T, bool>> query);
        Task<List<T>> Filtred(Func<T, bool> query);
    }
}
