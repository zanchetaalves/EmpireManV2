using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.App.ModelBuilders
{
    public class PedidoItensModelBuilder
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidoItensModelBuilder(IPedidoRepository pedidoRepository,
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

        public PedidoItens ConvertVmToEntity(PedidoItensViewModel vm)
        {
            return _mapper.Map<PedidoItens>(vm);
        }
    }
}
