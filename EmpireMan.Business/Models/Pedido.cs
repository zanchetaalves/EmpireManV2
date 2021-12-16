using System;
using System.Collections.Generic;

namespace EmpireMan.Business.Models
{
    public class Pedido : Entity
    {
        public Pedido()
        {

        }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorTotal { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual IEnumerable<PedidoItens> PedidoItens { get; set; }
    }
}