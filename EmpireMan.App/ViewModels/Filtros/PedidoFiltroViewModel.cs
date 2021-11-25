using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmpireMan.App.ViewModels
{
    public class PedidoFiltroViewModel
    {
        [DataType(DataType.Date)]
        [DisplayName("Data do Pedido")]
        public DateTime DataPedido { get; set; }

        [DisplayName("Produto")]
        public int? ProdutoId { get; set; }

        public List<ProdutoViewModel> ListaProdutos { get; set; }
        public List<PedidoViewModel> Pedidos { get; set; }
    }
}