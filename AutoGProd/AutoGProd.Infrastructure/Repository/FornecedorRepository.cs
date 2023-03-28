using AutoGProd.Domain.Entity;
using AutoGProd.Domain.Repository;
using AutoGProd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGProd.Infrastructure.Repository
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AutoglassContext context) : base(context)
        {
        }        
    }
}
