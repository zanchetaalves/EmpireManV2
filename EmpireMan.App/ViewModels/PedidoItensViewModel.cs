using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmpireMan.App.ViewModels
{
    public class PedidoItensViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Pedido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int PedidoId { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Quantidade { get; set; }

        [DisplayName("Valor Unitário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal ValorTotal { get; set; }

        [DisplayName("% Desconto")]
        public decimal PercentualDesconto { get; set; }

        [DisplayName("Desconto (R$)")]
        public decimal ValorDesconto { get; set; }


        public PedidoViewModel Pedido { get; set; }
        public List<ProdutoViewModel> ListaProdutos { get; set; }
    }
}