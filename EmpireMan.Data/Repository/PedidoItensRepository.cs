using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;

namespace EmpireMan.Data.Repository
{
    public class PedidoItensRepository : Repository<PedidoItens>, IPedidoItensRepository
    {
        public PedidoItensRepository(EmpireDbContext context) : base(context) { }
    }
}
