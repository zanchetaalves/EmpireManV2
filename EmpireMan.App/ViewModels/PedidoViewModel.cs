using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmpireMan.App.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataPedido { get; set; }

        [DisplayName("Total de Desconto")]
        public decimal ValorDesconto { get; set; }

        public List<PedidoViewModel> PedidoItens { get; set; }
    }
}