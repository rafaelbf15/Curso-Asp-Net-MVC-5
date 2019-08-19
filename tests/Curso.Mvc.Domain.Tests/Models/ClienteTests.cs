using Curso.Mvc.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Curso.Mvc.Domain.Tests.Models
{
    [TestClass]
    public class ClienteTests
    {
        // AAA => Arrange, Act, Assert
        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarTrue()
        {

            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                CPF = "65782707798",
                Email = "teste@gmail.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarFalse()
        {

            // Arrange
            var cliente = new Cliente
            {
                Nome = "E",
                CPF = "65782707799",
                Email = "teste2gmail.com",
                DataNascimento = DateTime.Now
            };

            // Act
            var result = cliente.EhValido();


            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "O nome do cliente precisa ter mais de 2 caracteres."));
        }
    }
}
