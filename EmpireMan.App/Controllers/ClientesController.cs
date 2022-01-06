using AutoMapper;
using EmpireMan.App.ViewModels;
using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteEnderecoRepository _clienteEnderecoRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository,
                                  IClienteEnderecoRepository clienteEnderecoRepository,
                                  IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _clienteEnderecoRepository = clienteEnderecoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            return View(clientes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var cliente = _mapper.Map<Cliente>(vm);
            await _clienteRepository.Adicionar(cliente);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel vm)
        {
            if (id != vm.Id) return NotFound();
            if (!ModelState.IsValid) return View(vm);

            var cliente = _mapper.Map<Cliente>(vm);
            await _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoriaVm = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (categoriaVm == null) return NotFound();

            return View(categoriaVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null) return NotFound();

            await _clienteRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AtualizarEndereco(int id)
        {
            var vm = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return PartialView("_AtualizarEndereco", new ClienteViewModel { ClienteEndereco = vm.ClienteEndereco });
        }

        [AllowAnonymous]
        public async Task<IActionResult> ObterEndereco(int id)
        {
            var vm = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (vm == null) return NotFound();

            return PartialView("_DetalhesEndereco", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(ClienteViewModel clienteViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Cpf");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", clienteViewModel);

            try
            {
                clienteViewModel.ClienteEndereco.Cliente = clienteViewModel;
                var clienteEndereco = _mapper.Map<ClienteEndereco>(clienteViewModel.ClienteEndereco);
                clienteEndereco.Cliente = null;
                await _clienteEnderecoRepository.Atualizar(clienteEndereco);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            

            var url = Url.Action("ObterEndereco", "Clientes", new { id = clienteViewModel.Id });
            return Json(new { success = true, url });
        }
    }
}
