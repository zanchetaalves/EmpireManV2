using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;

namespace EmpireMan.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EmpireDbContext context) : base(context) { }
    }
}
