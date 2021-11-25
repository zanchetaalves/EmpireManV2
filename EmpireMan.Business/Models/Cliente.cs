using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpireMan.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public virtual ClienteEndereco ClienteEndereco { get; set; }
        public virtual IEnumerable<Pedido> Pedidos { get; set; }
    }
}