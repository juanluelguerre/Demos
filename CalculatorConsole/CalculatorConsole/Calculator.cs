using System;

namespace ElGuerre.Demos.CalculartorConsole
{

    public class Calculator
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
