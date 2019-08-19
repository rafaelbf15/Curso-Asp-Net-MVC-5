using System;
using System.Web.Mvc;
using Curso.Mvc.Application.Interfaces;
using Curso.Mvc.Application.ViewModels;
using Curso.Mvc.Infra.CrossCuting.Filters;

namespace Curso.Mvc.Ui.Site.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
    
        [ClaimsAuthorize("Clientes", "LISTAR")]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Clientes", "DETALHES")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {

            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "INCLUIR")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Clientes", "INCLUIR")]
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            clienteEndereco = _clienteAppService.Adicionar(clienteEndereco);
            
            if(clienteEndereco.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(clienteEndereco.Cliente.ValidationResult);

            return View(clienteEndereco);

        }

        

        [ClaimsAuthorize("Clientes", "EDITAR")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {

            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "EDITAR")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);

                return RedirectToAction("Index");
            
        }

        [ClaimsAuthorize("Clientes", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {

            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();
      
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "EXCLUIR")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose();
        }

    }
}
