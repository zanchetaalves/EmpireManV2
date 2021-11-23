using System.Collections.Generic;

namespace EmpireMan.Business.Models
{
    public class PedidoItens : Entity
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorDesconto { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual IEnumerable<PedidoItensProduto> PedidoItensProdutos { get; set; }
    }
}