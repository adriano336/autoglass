using AutoGProd.Business.Dto;
using AutoGProd.Domain.Business;
using AutoGProd.Domain.Entity;
using AutoGProd.Domain.Repository;
using Tapioca.HATEOAS.Utils;

namespace AutoGProd.Business.Business
{
    public class ProdutoBusiness : ValidacaoBusiness, IProdutoBusiness, IGenericBusiness<Produto>
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoBusiness(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<Produto> Create(Produto entity)
        {
            Validar(entity);
            if (!PossuiErros)
            {
                return await produtoRepository.Create(entity);
            }

            return default;
        }

        private void Validar(Produto entity)
        {
            if (entity.DataValidade < entity.DataFabricacao)
            {
                AdicionarMensagem("Data de validade não pode ser anterior a data de fabricação.");
            }
        }

        public async Task Delete(long id)
        {
            var prd = await FindById(id);
            if (prd != null)
            {
                prd.Inativo = true;
                await produtoRepository.Update(prd);
                
            }
        }

        public Task<bool> Exists(long? id)
        {
            return produtoRepository.Exists(id);
        }

        public async Task<List<Produto>> FindAll()
        {
            return await produtoRepository.FindAll();
        }

        public async Task<Produto> FindById(long id)
        {
            return await produtoRepository.FindById(id);
        }

        public async Task<PagedSearchDTO<Produto>> FindWithPagedSearch(Func<Produto, bool> query, int start, int total)
        {

            var paged = await produtoRepository.FindWithPagedSearch(p => !p.Inativo, start - 1, total);
            var totalRecord = await produtoRepository.GetCount(p => !p.Inativo);
            return new PagedSearchDTO<Produto>
            {
                CurrentPage = start + 1,
                List = paged,
                TotalResults = totalRecord,
                PageSize = totalRecord / total
            };
        }

        public Task<int> GetCount(Func<Produto, bool> query)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> Update(Produto entity)
        {
            Validar(entity);

            if (!PossuiErros)
            {
                return await produtoRepository.Update(entity);
            }

            return default;
        }

        public async Task<IList<Produto>> EncontrarFiltro(FiltroProdutoDto filtro)
        {

            return await produtoRepository.Filtro(filtro);
        }

        public Task<Produto> FiltredRecord(Func<Produto, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
