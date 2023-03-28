using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGProd.Business.Dto;
using AutoGProd.Domain.Entity;

namespace AutoGProd.Domain.Repository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<IList<Produto>> Filtro(FiltroProdutoDto filtro);
    }
}
