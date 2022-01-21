using EmpireMan.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.Business.Interfaces
{
    public interface IPedidoItensRepository : IRepository<PedidoItens>
    {
        Task<IEnumerable<PedidoItens>> BuscarPorPedido(int pedidoId);
    }
}
