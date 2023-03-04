
using RandomFileGenerator;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;

Console.WriteLine("Generating file");


CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
ParsingTarget parseTarget = new ParsingTarget();
try
{
    parser.ExtractArgumentAttributes(parseTarget);
    parser.ParseCommandLine(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    parser.ShowUsageHeader = "Here is how you use the app: ";
    parser.ShowUsageFooter = "Have fun!";
    parser.ShowUsage();
    Environment.Exit(-1);
}

try
{
    var fg = new FileGenerator(parseTarget);
    fg.Generate();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
