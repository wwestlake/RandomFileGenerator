using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomFileGeneratorLib;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;

namespace RandomFileGenerator
{
    internal static class CommandParser
    {
        private static CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
        private static ParsingTarget parseTarget = new ParsingTarget();

        static CommandParser() 
        {
            parser.ExtractArgumentAttributes(parseTarget);
        }

        private static void ShowUsage()
        {
            parser.ShowUsageHeader = "Here is how you use the app: ";
            parser.ShowUsageFooter = "Have fun!";
            parser.ShowUsage();
        }
        public static Maybe<ParsingTarget> Parse(string command)
        {
            
            try
            {
                string[] options = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                parser.ParseCommandLine(options);
                string message = string.Empty;
                if (!parseTarget.Validate(out message))
                {
                    Console.WriteLine($"\n\nOoops ther was an error:  {message}\n\n");
                    ShowUsage();
                    return Maybe<ParsingTarget>.None();
                }

                return Maybe<ParsingTarget>.Some(parseTarget);
            } catch (Exception e) 
            { 
                Console.WriteLine("An error occured, check your syntax.");
                Console.WriteLine();
                Console.WriteLine(command);
                Console.WriteLine();
                parser.ShowUsage();
            }
            return Maybe<ParsingTarget>.None();
            
        }

    }
}
