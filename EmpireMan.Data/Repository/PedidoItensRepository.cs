using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.Data.Repository
{
    public class PedidoItensRepository : Repository<PedidoItens>, IPedidoItensRepository
    {
        public PedidoItensRepository(EmpireDbContext context) : base(context) { }

        public async Task<IEnumerable<PedidoItens>> BuscarPorPedido(int pedidoId)
        {
            return await Db?.PedidoItens.Where(x => x.PedidoId == pedidoId).ToListAsync();
        }
    }
}
