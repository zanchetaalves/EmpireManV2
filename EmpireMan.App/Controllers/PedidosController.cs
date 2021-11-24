using EmpireMan.App.ModelBuilders;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmpireMan.App.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly PedidoModelBuilder _pedidoModelBuilder;

        public PedidosController(PedidoModelBuilder pedidoModelBuilder)
        {
            _pedidoModelBuilder = pedidoModelBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _pedidoModelBuilder.CreateFrom();
            return View(vm);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var vm = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

        //    if (vm == null)
        //        return NotFound();

        //    return View(vm);
        //}

        //public async Task<IActionResult> Create()
        //{
        //    var vm = await ObterCategorias(new ProdutoViewModel());
        //    return View(vm);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ProdutoViewModel vm)
        //{
        //    if (!ModelState.IsValid) return View(vm);

        //    var imgPrefixo = string.Concat(Guid.NewGuid(), "_");

        //    if (!await UploadArquivo(vm.ImagemUpload, imgPrefixo)) return View(vm);

        //    vm.Imagem = imgPrefixo + vm.ImagemUpload.FileName;
        //    vm.DataCadastro = DateTime.Now;

        //    var produto = _mapper.Map<Produto>(vm);
        //    await _produtoRepository.Adicionar(produto);

        //    return RedirectToAction(nameof(Index));
        //}

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
    }
}
