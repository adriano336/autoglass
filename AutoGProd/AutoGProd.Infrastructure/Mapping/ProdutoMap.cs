using AutoGProd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGProd.Infrastructure.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao);
            builder.Property(x => x.DataFabricacao);
            builder.Property(x => x.DataValidade);
            builder.Property(x => x.Inativo);
            builder.Property(x => x.FornecedorId).IsRequired(false);
            builder.HasOne(f => f.Fornecedor)
                .WithMany(e => e.Produtos).HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Produtos");
        }
    }
}
