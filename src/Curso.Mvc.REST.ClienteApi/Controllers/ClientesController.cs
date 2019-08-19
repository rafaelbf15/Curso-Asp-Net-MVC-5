using Curso.Mvc.Application.Interfaces;
using Curso.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Curso.Mvc.REST.ClienteApi.Controllers
{
   // [EnableCors(origins: "*", headers:"*", methods:"*")]
   [MyCorsPolicy]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> ObterClientes()
        {
            return _clienteAppService.ObterAtivos();
        }

        [HttpGet]
        public ClienteViewModel ObterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _clienteAppService.Adicionar(clienteEndereco);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(Guid id, [FromBody]ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _clienteAppService.Atualizar(cliente);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            _clienteAppService.Remover(id);
            return Ok();
        }
    }
}
