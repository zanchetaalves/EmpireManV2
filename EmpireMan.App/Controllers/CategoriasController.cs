using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository,
                                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
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

            await _categoriaRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
