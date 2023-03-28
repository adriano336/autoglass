using AutoGProd.Domain.Entity;
using AutoGProd.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AutoGProd.Infrastructure.Context
{
    public class AutoglassContext : DbContext
    {
        public AutoglassContext(DbContextOptions<AutoglassContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoMap).Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
