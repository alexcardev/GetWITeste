using System;
using System.Collections.Generic;
using System.Text;

namespace GetWITeste.Core.Entities
{
    public class AppSettings
    {
        public string MensagemInicioProcesso { get; set; }
        public string MensagemFimProcesso { get; set; }
        public string ConnectionDb { get; set; }
        public string MensagemErro { get; set; }
        public string NomeOrganizacao { get; set; }
        public string TokenAcesso { get; set; }
        public string NomeProjeto { get; set; }
        public string Uri { get; set; }
    }
}
