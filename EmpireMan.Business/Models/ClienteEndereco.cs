using System;

namespace EmpireMan.Business.Models
{
    public class ClienteEndereco : Entity
    {
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}