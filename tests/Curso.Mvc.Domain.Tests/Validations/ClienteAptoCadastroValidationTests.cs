using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Mvc.Domain.Tests.Validations
{
    [TestClass]
    public class ClienteAptoCadastroValidationTests
    {

        [TestMethod]
        public void ClienteAptoCadastro_Validation_DeveRetornar_True()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                CPF = "65782707798",
                Email = "teste@gmail.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            // MOQ
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);


            // Act
            var result = cliValidation.Validate(cliente);

            // Assert
            Assert.IsTrue(result.IsValid);

        }

        [TestMethod]
        public void ClienteAptoCadastro_Validation_DeveRetornar_False()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                CPF = "65782707798",
                Email = "teste@gmail.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            // MOQ
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);


            // Act
            var result = cliValidation.Validate(cliente);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este CPF."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este E-mail."));

        }




    }
}
