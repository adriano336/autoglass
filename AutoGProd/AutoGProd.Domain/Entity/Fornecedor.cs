namespace AutoGProd.Domain.Entity
{
    public class Fornecedor : Entity
    {        
        public string NomeFornecedor { get; set; }
        public string CNPJ { get; set; }
        public IList<Produto> Produtos { get; set; }
    }
}