namespace AutoGProd.Domain.Business
{
    public interface IValidacaoBusiness
    {
        Boolean PossuiErros { get; }
        string MensagemErro { get; }


    }
}
