using System;
using System.Collections.Generic;

namespace EmpireMan.App.ViewModels
{
    public class PedidoFiltroViewModel
    {
        public DateTime? DataPedido { get; set; }
        public int? ProdutoId { get; set; }

        public List<ProdutoViewModel> ListaProdutos { get; set; }
        public List<PedidoItensViewModel> PedidoItens { get; set; }
    }
}