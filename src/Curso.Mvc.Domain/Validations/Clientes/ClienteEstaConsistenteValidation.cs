using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Specifications;
using Curso.Mvc.Domain.Specifications.Clientes;
using Curso.Mvc.Domain.Value_Objects;
using DomainValidation.Validation;

namespace Curso.Mvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            //var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();
            var clienteNomeCurto = new GenericSpecification<Cliente>(c => c.Nome.Length >= 2);
            var clienteEmailVazio = new GenericSpecification<Cliente>(c => !string.IsNullOrWhiteSpace(c.Email));
            var CPFCliente = new GenericSpecification<Cliente>(c => CPF.Validar(c.CPF));

            Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
            Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
            Add("clienteNomeCurto", new Rule<Cliente>(clienteNomeCurto, "O nome do cliente precisa ter mais de 2 caracteres."));
            Add("clienteEmailVazio", new Rule<Cliente>(clienteEmailVazio, "O e-mail não pode estar em branco."));
        }
    }
}
