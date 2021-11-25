using EmpireMan.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> BuscarPorFiltros(DateTime dataPedido);
    }
}
