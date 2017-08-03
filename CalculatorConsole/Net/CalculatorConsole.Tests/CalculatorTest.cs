using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElGuerre.Demos.CalculartorConsole;

namespace CalculatorConsole.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SumTest()
        {
            var c = new Calculator();
            var total = c.Sum(1, 1);
            Assert.AreEqual(total, 2);
        }

        [TestMethod]
        public void DivideTest()
        {
            var c = new Calculator();
            var result = c.Divide(1, 1);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivideInvalidOperationExceptionTest()
        {
            var c = new Calculator();
            c.Divide(1, 2);
        }

        [TestMethod]
        public void DivideSiBCeroTest()
        {
            var c = new Calculator();
            var result = c.Divide(1, 0);
            Assert.AreEqual(result, 1);
        }
    }
}
