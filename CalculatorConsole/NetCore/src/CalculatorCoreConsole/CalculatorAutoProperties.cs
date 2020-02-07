using System;
namespace CalculatorCoreConsole
{
    public class CalculatorAutoProperties
    {

		/**********************/
		// 1) Auto properties
		/**********************/
		
        public CalculatorAutoProperties(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
            // Value3 = 3;
            Value33 = 33; // En el Construnctor tiene prioridad frente a la asignación directa en la propiedad.
        }

        // Antes de C# 6
        public readonly int value3;

        public int Value3
        {
            get { return value3; }
        }

        // Inmutabilidad con C#6
        public int Value33 { get; } = 33;


        public int Value1 { get; }
        public int Value2 { get; }


		/**********************/
		// 2) Expresions Body
        // No presenta ninguna penalización de performance.
		/**********************/

		// Opción 1 (antes de C#6)
		public int SumaPositivos 
        {
            get { return (Value1 < 0) ? 0 : (Value2 < 0) ? 0 : Value1 + Value2; }
        }

        // Opción 2 (C# 6).
		public int SumaPositivosCS6 => (Value1 < 0) ? 0 : (Value2 < 0) ? 0 : Value1 + Value2;

        // Asignación predeterminada
        public int Value4 => 44;
        // Cuidado con la confusión:  public int Value4 = 44;

        //
        // Cuidado con los comentarios. Una propiedad con un Expresion Body, puede causar una peor legibilidad+
        // En este caso, es preferible utilizar el mécanimos tradicional y no el método abreviado dado que empeora la legibilidad del código.
        //
        /// <summary>
        /// Suma de dos números conviertiendo los mismos a positivos en caso de ser negativos.
        /// </summary>
        /// <value>Resultado de la suma tras la converión a numeros positivos si aplica.</value>
        public int SumaPositivosCS6Commented => 
            // La suma convierte previamente los números negativos a positivos
            (Value1 < 0) ? Value4 *(-1) : (Value2 < 0) ? Value4 * (-1) : Value1 + Value2;


		public int Suma => Value1 + Value2;
    }
}