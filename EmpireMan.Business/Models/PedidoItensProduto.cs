namespace EmpireMan.Business.Models
{
    public class PedidoItensProduto
    {
        public int PedidoItensId { get; set; }
        public PedidoItens PedidoItens { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}