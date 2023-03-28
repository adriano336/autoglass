using AutoGProd.Domain.Business;

namespace AutoGProd.Business.Business
{
    public class ValidacaoBusiness : IValidacaoBusiness
    {
        public bool PossuiErros { get => Mensagens.Count > 0; }
        public IList<string> Mensagens { get; set; }
        public string MensagemErro { get => Mensagens.First(); }

        public ValidacaoBusiness()
        {
            Mensagens = new List<string>();
        }

        protected void AdicionarMensagem(string mensagem)
        {
            Mensagens.Add(mensagem);
        }
    }
}
