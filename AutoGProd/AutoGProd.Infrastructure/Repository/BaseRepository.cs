using AutoGProd.Domain.Entity;
using AutoGProd.Domain.Repository;
using AutoGProd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoGProd.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly AutoglassContext _context;
        protected DbSet<T> dataset;

        public BaseRepository(AutoglassContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                await dataset.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public async Task Delete(long id)
        {
            var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

            try
            {
                if (result != null) dataset.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Exists(long? id) => await dataset.AnyAsync(e => e.Id.Equals(id));

        public async Task<List<T>> Filtred(Func<T, bool> query)
        {
            return await Task.Run(() => dataset.Where(query).ToList());
        }

        public async Task<List<T>> FindAll() => await dataset.ToListAsync();

        public virtual async Task<T> FindById(long id) => await dataset.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);

        public virtual async Task<List<T>> FindWithPagedSearch(Func<T, bool> query, int start, int total) => await Task.FromResult(dataset.Where(query).Skip(start).Take(total).ToList());

        public async Task<int> GetCount(Expression<Func<T, bool>> query) => await dataset.CountAsync(query, CancellationToken.None);

        public async Task<T> Update(T entity)
        {
            if (await Exists(entity.Id)) return null;

            var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }
    }
}
