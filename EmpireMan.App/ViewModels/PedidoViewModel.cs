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
        [DataType(DataType.Date)]
        public DateTime DataPedido { get; set; }

        [DisplayName("Total de Desconto")]
        public decimal ValorDesconto { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }


        public ClienteViewModel Cliente { get; set; }
        public List<PedidoItensViewModel> PedidoItens { get; set; }
    }
}