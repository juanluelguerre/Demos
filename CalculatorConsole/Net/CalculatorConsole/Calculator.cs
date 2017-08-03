using System;

namespace ElGuerre.Demos.CalculartorConsole
{
    /// <summary>
    /// Calculte integer operations
    /// </summary>
    public class Calculator : ICalculator
    {

        /// <summary>
        /// Sums the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public int Sum(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Divides the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Divide(int a, int b)
        {
            if (a < b)
                throw new InvalidOperationException();

            if (a <= 0)
                return 0;

            if (b == 0)
                return a;


            return a / b;
        }
    }
}
