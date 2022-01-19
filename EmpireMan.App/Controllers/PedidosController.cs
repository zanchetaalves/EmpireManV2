using AutoMapper;
using EmpireMan.App.ModelBuilders;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly PedidoModelBuilder _pedidoModelBuilder;
        private readonly PedidoItensModelBuilder _pedidoItensModelBuilder;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidosController(PedidoModelBuilder pedidoModelBuilder,
                                 PedidoItensModelBuilder pedidoItensModelBuilder,
                                 IPedidoRepository pedidoRepository,
                                 IPedidoItensRepository pedidoItensRepository,
                                 IProdutoRepository produtoRepository,
                                 IClienteRepository clienteRepository,
                                 IMapper mapper)
        {
            _pedidoModelBuilder = pedidoModelBuilder;
            _pedidoItensModelBuilder = pedidoItensModelBuilder;
            _pedidoRepository = pedidoRepository;
            _pedidoItensRepository = pedidoItensRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _pedidoModelBuilder.CreateFromIndex();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consultar(PedidoFiltroViewModel vm)
        {
            vm.Pedidos = _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.BuscarPorFiltros(vm.DataPedido)).ToList();

            return View(nameof(Index), vm);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var vm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

        //    if (vm == null)
        //        return NotFound();

        //    return View(vm);
        //}

        public async Task<IActionResult> Create()
        {
            var vm = await _pedidoModelBuilder.CreateFromCadastro();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoCadastroViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var pedido = _pedidoModelBuilder.ConvertVmToEntity(vm.PedidoViewModel);
            await _pedidoRepository.Adicionar(pedido);

            //var pedidoItens = _pedidoItensModelBuilder.ConvertVmToEntity(vm.PedidoItensViewModel);
            //pedidoItens.PedidoId = pedido.Id;
            //await _pedidoItensRepository.Adicionar(pedidoItens);

            vm.PedidoViewModel.ListaDeCliente = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()).ToList();
            vm.PedidoItensViewModel.ListaProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos()).ToList();
            //vm.ListaPedidoItensViewModel = _mapper.Map<IEnumerable<PedidoItensViewModel>>(await _pedidoItensRepository.Buscar(x => x.PedidoId == pedido.Id)).ToList();
            vm.PedidoViewModel.Id = pedido.Id;

            return View(nameof(Create), vm);
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var produtoVm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

        //    if (produtoVm == null) return NotFound();

        //    return View(produtoVm);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ProdutoViewModel vm)
        //{
        //    if (id != vm.Id) return NotFound();
        //    if (!ModelState.IsValid) return View(vm);

        //    var produtoAtual = await _produtoRepository.ObterPorId(id);
        //    vm.Imagem = produtoAtual.Imagem;

        //    if (vm.ImagemUpload != null)
        //    {
        //        var imgPrefixo = string.Concat(Guid.NewGuid(), "_");
        //        if (!await UploadArquivo(vm.ImagemUpload, imgPrefixo)) return View(vm);

        //        produtoAtual.Imagem = string.Concat(imgPrefixo, vm.ImagemUpload.FileName);
        //    }

        //    produtoAtual.Descricao = vm.Descricao;
        //    produtoAtual.CodigoBarras = vm.CodigoBarras;
        //    produtoAtual.Valor = vm.Valor;
        //    produtoAtual.Ativo = vm.Ativo;

        //    var produto = _mapper.Map<Produto>(produtoAtual);
        //    await _produtoRepository.Atualizar(produto);

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var produtoVm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

        //    if (produtoVm == null) return NotFound();

        //    return View(produtoVm);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var produto = await _produtoRepository.ObterPorId(id);

        //    if (produto == null) return NotFound();

        //    if (produto.ProdutoEstoque != null)
        //        await _produtoEstoqueRepository.Remover(produto.ProdutoEstoque.Id);

        //    await _produtoRepository.Remover(id);

        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<ProdutoViewModel> ObterCategorias(ProdutoViewModel vm)
        //{
        //    vm.ListaCategorias = _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        //    return vm;
        //}

        //private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        //{
        //    if (arquivo.Length <= 0) return false;

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagensProdutos", string.Concat(imgPrefixo, arquivo.FileName));

        //    if (System.IO.File.Exists(path))
        //    {
        //        ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome. Tente novamente.");
        //        return false;
        //    }

        //    using (var stream = new FileStream(path, FileMode.Create))
        //        await arquivo.CopyToAsync(stream);

        //    return true;
        //}

        public async Task<IActionResult> AdicionarProduto(int id)
        {
            var vm = new PedidoItensViewModel();
            vm.ListaProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos()).ToList();

            return PartialView("_AdicionarProduto", vm);
        }
    }
}
