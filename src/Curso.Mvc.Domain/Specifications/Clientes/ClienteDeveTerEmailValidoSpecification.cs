using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Value_Objects;
using DomainValidation.Interfaces.Specification;

namespace Curso.Mvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Email.Validar(cliente.Email);
        }
    }

}
