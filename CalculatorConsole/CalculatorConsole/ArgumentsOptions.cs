using CommandLine;
using CommandLine.Text;
using System;

namespace ElGuerre.Demos.CalculatorConsole
{
    public enum OperationType
    {
        suma,
        divide
    }
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

            ////// Creates a new HelpText string
            ////HelpText helpText = new HelpText
            ////{
            ////    Heading = new HeadingInfo("CalculatorConsose", "1.0.0.0"),
            ////    Copyright = new CopyrightInfo("Juanlu, ElGuerre", DateTime.Now.Year),
            ////    AdditionalNewLineAfterOption = false,
            ////    AddDashesToOption = true,
            ////    MaximumDisplayWidth = 200
            ////};

            ////// Checks for parsing errors
            ////if (this.LastParserState.Errors.Count > 0)
            ////{
            ////    // Indent errors with 2 spaces
            ////    string errors = helpText.RenderParsingErrorsText(this, 2);

            ////    // Prints the parsing errors
            ////    if (!String.IsNullOrEmpty(errors))
            ////    {
            ////        helpText.AddPreOptionsLine(errors);
            ////        helpText.AddPreOptionsLine("Refer to user manual (--help) for further instructions.");
            ////    }

            ////}
            ////else
            ////{
            ////    // Prints the user manual
            ////    helpText.AddPreOptionsLine("Usage: this, this and that");
            ////    helpText.AddOptions(this);
            ////}

            ////return helpText;


        }
    }
}
