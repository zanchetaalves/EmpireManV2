using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  ICategoriaRepository categoriaRepository,
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listaDeProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return View(listaDeProdutos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

            if (vm == null)
                return NotFound();

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await ObterCategorias(new ProdutoViewModel());
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var produto = _mapper.Map<Produto>(vm);
            await _produtoRepository.Adicionar(produto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produtoVm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

            if (produtoVm == null) return NotFound();

            return View(produtoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel vm)
        {
            if (id != vm.Id) return NotFound();
            if (!ModelState.IsValid) return View(vm);

            var produto = _mapper.Map<Produto>(vm);
            await _produtoRepository.Atualizar(produto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produtoVm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

            if (produtoVm == null) return NotFound();

            return View(produtoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null) return NotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterCategorias(ProdutoViewModel vm)
        {
            vm.ListaCategorias = _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
            return vm;
        }
    }
}
