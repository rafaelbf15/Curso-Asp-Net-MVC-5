using Curso.Mvc.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;

namespace Curso.Mvc.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }

}
