using System;
using ElGuerre.Demos.CalculartorConsole;
using Xunit;

namespace CalculatorCoreConsoleTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 1)]
        public void SumTest(int a, int b)
        {
            var calc = new Calculator();            
            Assert.Equal(2, calc.Sum(a, b));
        }

        [Theory]
        [InlineData(1, 1)]
        public void DivideTest(int a, int b)
        {
            var calc = new Calculator();
            Assert.Equal(1, calc.Divide(a, b));

        }

    }
}
