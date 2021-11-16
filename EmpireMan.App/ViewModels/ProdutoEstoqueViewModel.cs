using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmpireMan.App.ViewModels
{
    public class ProdutoEstoqueViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Quantidade { get; set; }

        public ProdutoViewModel Produto { get; set; }
        public List<ProdutoViewModel> ListaProdutos { get; set; }
    }
}