using AutoGProd.Business.Dto;
using AutoGProd.Domain.Entity;

namespace AutoGProd.Domain.Business
{
    public interface IProdutoBusiness : IValidacaoBusiness, IGenericBusiness<Produto>
    {
        Task<IList<Produto>> EncontrarFiltro(FiltroProdutoDto filtro);
    }
}
