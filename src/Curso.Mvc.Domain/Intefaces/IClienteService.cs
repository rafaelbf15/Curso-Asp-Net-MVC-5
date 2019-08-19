using Curso.Mvc.Domain.Models;
using System;

namespace Curso.Mvc.Domain.Intefaces
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}
