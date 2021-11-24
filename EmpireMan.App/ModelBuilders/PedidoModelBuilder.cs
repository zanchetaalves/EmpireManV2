using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.App.ModelBuilders
{
    public class PedidoModelBuilder
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;
        private readonly IMapper _mapper;

        public PedidoModelBuilder(IPedidoRepository pedidoRepository,
                                  IPedidoItensRepository pedidoItensRepository,
                                  IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoItensRepository = pedidoItensRepository;
            _mapper = mapper;
        }

        public async Task<PedidoFiltroViewModel> CreateFrom()
        {
            var vm = new PedidoFiltroViewModel();
            vm.Pedidos = _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterTodos()).ToList();

            return vm;
        }
    }
}
