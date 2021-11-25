using System.Collections.Generic;

namespace EmpireMan.App.ViewModels
{
    public class PedidoCadastroViewModel
    {
        public PedidoCadastroViewModel()
        {
            PedidoViewModel = new PedidoViewModel();
            PedidoItensViewModel = new PedidoItensViewModel();
            ListaPedidoItensViewModel = new List<PedidoItensViewModel>();
        }
        public PedidoViewModel PedidoViewModel { get; set; }
        public PedidoItensViewModel PedidoItensViewModel { get; set; }
        public List<PedidoItensViewModel> ListaPedidoItensViewModel { get; set; }
    }
}