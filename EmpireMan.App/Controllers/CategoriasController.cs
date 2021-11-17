using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository,
                                    IProdutoRepository produtoRepository,
                                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listaDeCategorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
            return View(listaDeCategorias);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));

            if (vm == null)
                return NotFound();

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var categoria = _mapper.Map<Categoria>(vm);
            await _categoriaRepository.Adicionar(categoria);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriaVm = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));

            if (categoriaVm == null) return NotFound();

            return View(categoriaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel vm)
        {
            if (id != vm.Id) return NotFound();
            if (!ModelState.IsValid) return View(vm);

            var categoria = _mapper.Map<Categoria>(vm);
            await _categoriaRepository.Atualizar(categoria);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoriaVm = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));

            if (categoriaVm == null) return NotFound();

            return View(categoriaVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);

            if (categoria == null) return NotFound();

            if (categoria.Produtos != null)
                throw new Exception("Não foi possível excluir a categoria, existem produtos vínculados a mesma.");

            await _categoriaRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
