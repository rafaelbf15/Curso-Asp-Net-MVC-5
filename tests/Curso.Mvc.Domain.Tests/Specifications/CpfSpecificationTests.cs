using Curso.Mvc.Domain.Models;
using Curso.Mvc.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Mvc.Domain.Tests.Specifications
{
    [TestClass]
    public class CpfSpecificationTests
    {

        [TestMethod]
        public void CpfSpecification_Valido_True()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                CPF = "65782707798",
                Email = "teste@gmail.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();


            // Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CpfSpecification_Valido_False()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                CPF = "65782707790",
                Email = "teste@gmail.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();


            // Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsFalse(result);

        }

    }
}
