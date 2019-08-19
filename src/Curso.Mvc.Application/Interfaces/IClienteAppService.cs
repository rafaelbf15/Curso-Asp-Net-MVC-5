using System;
using System.Collections.Generic;
using Curso.Mvc.Application.ViewModels;

namespace Curso.Mvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        IEnumerable<ClienteViewModel> ObterAtivos();
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        void Remover(Guid id);
    }
}