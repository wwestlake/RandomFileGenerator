using RandomFileGeneratorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace RandomFileGenerator
{
    internal class InteractiveMode
    {
        private bool _running = true;
        private const string _prompt = "lrfg> ";



        public void Run()
        {
            Output("Welcome to Lagdaemon's Random File Generator");
            Output("Interactive Mode");

            while (_running)
            {
                DisplayPrompt(_prompt);
                var input = Read();
                Console.WriteLine(input);
                input = input.Trim();
                if (input.Length == 0) continue;
                var options = CommandParser.Parse(input);
                if (options != null && options.HasValue)
                {
                    var fg = new FileGenerator(options.Value);
                    fg.Generate();
                } else
                {
                    Console.WriteLine($"Ooops something went wrong");
                }
            }

        }

        private void Output(string message)
        {
            Console.WriteLine(message);
        }

        private void DisplayPrompt(string prompt)
        {
            Console.Write(prompt);
            Console.Out.Flush();
        }

        private string Read()
        {
            var result = ReadLine.Read();
            ReadLine.AddHistory(result);
            return result;
        }

    }
}
