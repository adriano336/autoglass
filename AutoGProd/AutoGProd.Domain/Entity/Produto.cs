namespace AutoGProd.Domain.Entity
{
    public class Produto : Entity
    {       
        public string Descricao { get; set; }
        public bool Inativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
