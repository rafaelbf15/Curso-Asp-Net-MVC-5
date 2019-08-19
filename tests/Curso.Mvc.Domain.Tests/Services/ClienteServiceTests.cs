using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Mvc.Domain.Tests.Services
{
    [TestClass]
    public class ClienteServiceTests
    {

        [TestMethod]
        public void ClienteService_AdicionarCliente_RetornarComSucesso()
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
            var clienteService = new ClienteService(repo);


            // Act
            var result = clienteService.Adicionar(cliente);

            // Assert
            Assert.IsTrue(result.ValidationResult.IsValid);

        }


    }
}
