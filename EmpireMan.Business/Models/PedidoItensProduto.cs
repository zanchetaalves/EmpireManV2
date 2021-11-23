namespace EmpireMan.Business.Models
{
    public class PedidoItensProduto
    {
        public int PedidoItensId { get; set; }
        public virtual PedidoItens PedidoItens { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}