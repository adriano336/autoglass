namespace AutoGProd.Business.Dto
{
    public class ProdutoDto : EntityDto
    {
        public string? Descricao { get; set; }
        public bool Inativo { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? FornecedorId { get; set; }
        public FornecedorDto? Fornecedor { get; set; }
    }
}
