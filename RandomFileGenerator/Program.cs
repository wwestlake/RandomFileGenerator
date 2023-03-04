
using RandomFileGeneratorLib;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using RandomFileGeneratorLib.Policies;

Console.WriteLine("Generating file");
ParsingTarget parseTarget = new ParsingTarget();
CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();

void ShowUsage()
{
    parser.ShowUsageHeader = "Here is how you use the app: ";
    parser.ShowUsageFooter = "Have fun!";
    parser.ShowUsage();
    Environment.Exit(-1);
}




try
{
   
    parser.ExtractArgumentAttributes(parseTarget);
    parser.ParseCommandLine(args);
    string message = string.Empty;
    if (!parseTarget.Validate(out message))
    {
        Console.WriteLine($"\n\nOoops ther was an error:  {message}\n\n");
        ShowUsage();
        Environment.Exit(-1);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    ShowUsage();
}

try
{
    var fg = new FileGenerator(parseTarget);
    fg.Generate();

    //ParagraphGenerator paragraphGenerator = new LoremIpsumParagraphGenerator();
    //
    //var text = paragraphGenerator.CreateParagraph(100,false);
    //
    //Console.WriteLine(text);

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
