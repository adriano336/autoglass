using AutoGProd.Business.Business;
using AutoGProd.Domain.Business;
using AutoGProd.Domain.Repository;
using AutoGProd.Infrastructure.Context;
using AutoGProd.Infrastructure.Repository;
using AutoMapper;

namespace AutoGProd.Web.Repository
{
    public static class RepositoryDependencyInjectionService
    {
        public static IServiceCollection InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddScoped<AutoglassContext>();

            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            services.AddScoped<IFornecedorBusiness, FornecedorBusiness>();

            return services;
        }
    }
}
