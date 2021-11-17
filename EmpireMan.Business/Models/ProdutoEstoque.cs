namespace EmpireMan.Business.Models
{
    public class ProdutoEstoque : Entity
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
    }
}