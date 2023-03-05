
using RandomFileGeneratorLib;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using RandomFileGeneratorLib.Policies;
using RandomFileGenerator;

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
    var i = 3;
    
}
catch (MandatoryArgumentNotSetException)
{
    Console.WriteLine("Entering Interactive More");

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    ShowUsage();
}

try
{
    if (parseTarget.Filename != null)
    {
        string message = string.Empty;
        if (!parseTarget.Validate(out message))
        {
            Console.WriteLine($"\n\nOoops ther was an error:  {message}\n\n");
            ShowUsage();
            Environment.Exit(-1);
        }
        var fg = new FileGenerator(parseTarget);
        fg.Generate();
    } else
    {
        var interact = new InteractiveMode();
        interact.Run();
    }



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
