using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.App.ModelBuilders
{
    public class PedidoModelBuilder
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidoModelBuilder(IPedidoRepository pedidoRepository,
                                  IPedidoItensRepository pedidoItensRepository,
                                  IProdutoRepository produtoRepository,
                                  IClienteRepository clienteRepository,
                                  IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoItensRepository = pedidoItensRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<PedidoFiltroViewModel> CreateFromIndex()
        {
            var vm = new PedidoFiltroViewModel();
            vm.DataPedido = DateTime.Now;
            vm.Pedidos = _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterTodos()).ToList();

            return vm;
        }

        public async Task<PedidoCadastroViewModel> CreateFromCadastro()
        {
            var vm = new PedidoCadastroViewModel();
            vm.PedidoViewModel.DataPedido = DateTime.Now;
            vm.PedidoViewModel.ListaDeCliente = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()).ToList();
            vm.PedidoItensViewModel.ListaProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos()).ToList();

            return vm;
        }
    }
}
