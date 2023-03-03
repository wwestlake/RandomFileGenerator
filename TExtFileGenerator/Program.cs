
using RandomFileGenerator;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;

Console.WriteLine("Generating file");


CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
ParsingTarget p = new ParsingTarget();
    try
    {
        parser.ExtractArgumentAttributes(p);
        parser.ParseCommandLine(args);

        Console.WriteLine($"Generating file {p.Filename} of size {p.Size} {p.Unit} -- {p.FileType}");

    }
    catch (Exception ex)
    {

        parser.ShowUsageHeader = "Here is how you use the app: ";
        parser.ShowUsageFooter = "Have fun!";
        parser.ShowUsage();
    }

