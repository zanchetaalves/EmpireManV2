using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;

namespace EmpireMan.Data.Repository
{
    public class ProdutoEstoqueRepository : Repository<ProdutoEstoque>, IProdutoEstoqueRepository
    {
        public ProdutoEstoqueRepository(EmpireDbContext context) : base(context) { }
    }
}
