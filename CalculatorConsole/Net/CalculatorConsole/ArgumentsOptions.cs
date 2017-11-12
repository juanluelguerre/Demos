using CommandLine;
using CommandLine.Text;

namespace ElGuerre.Demos.CalculatorConsole
{
    public enum OperationType
    {
        suma,
        divide
    }

    /// <summary>
    /// Arguments to use calcultor in command line
    /// </summary>
    public class ArgumentsOptions
    {
        [Option('o', "op", Required = true,
            HelpText = "Tipo de operación (Suma | Divide)")]
        public OperationType Operacion { get; set; }

        [ValueOption(1)]
        public int Value1 { get; set; }

        [ValueOption(2)]
        public int Value2 { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
