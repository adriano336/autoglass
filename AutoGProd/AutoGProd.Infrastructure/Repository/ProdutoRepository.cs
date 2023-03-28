using AutoGProd.Business.Dto;
using AutoGProd.Domain.Entity;
using AutoGProd.Domain.Repository;
using AutoGProd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoGProd.Infrastructure.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AutoglassContext context) : base(context)
        {
        }

        public override async Task<List<Produto>> FindWithPagedSearch(Func<Produto, bool> query, int start, int total)
        {
            return await Task.FromResult(dataset.Include(p => p.Fornecedor).Where(query).Skip(start).Take(total).ToList());
        }

        public override async Task<Produto> FindById(long id) => await dataset.Include(p => p.Fornecedor).SingleOrDefaultAsync(l => l.Id == id);

        public async Task<IList<Produto>> Filtro(FiltroProdutoDto filtro)
        {
            return await dataset.Include(f => f.Fornecedor)
                .AsNoTracking()
                .Where(p => (string.IsNullOrEmpty(filtro.NomeFornecedor) || p.Fornecedor.NomeFornecedor.ToUpper().Contains(filtro.NomeFornecedor.ToUpper()))
                && (String.IsNullOrEmpty(filtro.Descricao) || p.Descricao.ToUpper().Contains(filtro.Descricao.ToUpper())))
                .ToListAsync();
        }
    }
}
