namespace AutoGProd.Business.Dto
{
    public class FormProdutoDto
    {
        public IList<FornecedorDto> Fornecedores { get; set; }
        public ProdutoDto Produto { get; set; }
    }
}
