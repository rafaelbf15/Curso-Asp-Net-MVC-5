using Curso.Mvc.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Mvc.Domain.Tests.ValueObjects
{
    [TestClass]
    public class CPFValidation
    {
        [TestMethod]
        public void CPF_Valido_True()
        {
            // Arrange
            var CPFTest = "65782707798";

            // Act
            var result = CPF.Validar(CPFTest);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("303.906.008-22")]
        [DataRow("65782707790")]
        [DataRow("11111111111")]
        public void CPF_Valido_False(string cpf)
        {
            // Arrange
            //var CPFTest = "303.906.008-22";

            // Act
            var result = CPF.Validar(cpf);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
