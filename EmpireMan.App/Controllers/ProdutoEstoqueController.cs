using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class ProdutoEstoqueController : BaseController
    {
        private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoEstoqueController(IProdutoEstoqueRepository produtoEstoqueRepository,
                                  IProdutoRepository produtoRepository,
                                  IMapper mapper)
        {
            _produtoEstoqueRepository = produtoEstoqueRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listaDeEstoque = _mapper.Map<IEnumerable<ProdutoEstoqueViewModel>>(await _produtoEstoqueRepository.ObterTodos());
            return View(listaDeEstoque);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = _mapper.Map<ProdutoEstoqueViewModel>(await _produtoEstoqueRepository.ObterPorId(id));

            if (vm == null)
                return NotFound();

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await ObterProdutos(new ProdutoEstoqueViewModel());
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoEstoqueViewModel vm)
        {
            vm.Produto = null;
            var entity = _mapper.Map<ProdutoEstoque>(vm);
            await _produtoEstoqueRepository.Adicionar(entity);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = _mapper.Map<ProdutoEstoqueViewModel>(await _produtoEstoqueRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoEstoqueViewModel vm)
        {
            if (id != vm.Id) return NotFound();
            
            vm.Produto = null;

            var entity = _mapper.Map<ProdutoEstoque>(vm);
            await _produtoEstoqueRepository.Atualizar(entity);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vm = _mapper.Map<ProdutoEstoqueViewModel>(await _produtoRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _produtoEstoqueRepository.ObterPorId(id);

            if (entity == null) return NotFound();

            await _produtoEstoqueRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoEstoqueViewModel> ObterProdutos(ProdutoEstoqueViewModel vm)
        {
            vm.ListaProdutos = _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return vm;
        }
    }
}
