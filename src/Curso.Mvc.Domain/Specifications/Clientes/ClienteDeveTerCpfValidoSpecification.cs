using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Value_Objects;
using DomainValidation.Interfaces.Specification;

namespace Curso.Mvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }

}
