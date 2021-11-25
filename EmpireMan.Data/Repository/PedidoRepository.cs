using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EmpireDbContext context) : base(context) { }

        public async Task<IEnumerable<Pedido>> BuscarPorFiltros(DateTime dataPedido)
        {
            return await Db?.Pedidos.Where(x => x.DataPedido.Year == dataPedido.Year &&
                                                          x.DataPedido.Month == dataPedido.Month &&
                                                          x.DataPedido.Day == dataPedido.Day).ToListAsync();
        }
    }
}
