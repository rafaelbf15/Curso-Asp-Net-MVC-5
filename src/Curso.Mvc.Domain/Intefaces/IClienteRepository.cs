using Curso.Mvc.Domain.Models;
using System.Collections.Generic;

namespace Curso.Mvc.Domain.Intefaces
{
    public interface IClienteRepository : IRepositoryRead<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
    }
}
