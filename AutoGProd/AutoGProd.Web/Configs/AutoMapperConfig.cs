using AutoGProd.Business.Dto;
using AutoGProd.Domain.Entity;
using AutoMapper;


namespace AutoGProd.Web.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
