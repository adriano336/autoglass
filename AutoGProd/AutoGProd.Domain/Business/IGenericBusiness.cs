using Tapioca.HATEOAS.Utils;

namespace AutoGProd.Domain.Business
{
    public interface IGenericBusiness <T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> FindById(long id);
        Task<List<T>> FindAll();
        Task<T> Update(T entity);
        Task Delete(long id);
        Task<bool>  Exists(long? id);
        Task<PagedSearchDTO<T>> FindWithPagedSearch(Func<T, bool> query, int start, int total);
        Task<int> GetCount(Func<T, bool> query);
        Task<T> FiltredRecord(Func<T, bool> query);
    }
}
