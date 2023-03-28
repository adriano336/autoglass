using AutoGProd.Domain.Business;
using AutoGProd.Domain.Entity;
using AutoGProd.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapioca.HATEOAS.Utils;

namespace AutoGProd.Business.Business
{
    public class FornecedorBusiness : ValidacaoBusiness, IFornecedorBusiness
    {
        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorBusiness(IFornecedorRepository fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        public Task<Fornecedor> Create(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> FiltredRecord(Func<Fornecedor, bool> query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Fornecedor>> FindAll()
        {
            return await fornecedorRepository.FindAll();
        }

        public Task<Fornecedor> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedSearchDTO<Fornecedor>> FindWithPagedSearch(Func<Fornecedor, bool> query, int start, int total)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(Func<Fornecedor, bool> query)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> Update(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
