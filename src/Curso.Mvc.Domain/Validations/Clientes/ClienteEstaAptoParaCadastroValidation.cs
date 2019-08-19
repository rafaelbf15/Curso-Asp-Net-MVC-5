using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Specifications.Clientes;
using DomainValidation.Validation;

namespace Curso.Mvc.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {

        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteCpfUnico = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteEamilUnico = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            Add("clienteCpfUnico", new Rule<Cliente>(clienteCpfUnico, "Já existe um cliente com este CPF."));
            Add("clienteEamilUnico", new Rule<Cliente>(clienteEamilUnico, "Já existe um cliente com este E-mail."));

        }
    }
}
