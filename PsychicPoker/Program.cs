using PsychicPoker.Domain;
using PsychicPoker.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.Error.WriteLine("File name required");
                return;
            }

            var path = args[0];

            if (!File.Exists(path)) {
                Console.Error.WriteLine("File does not exists");
                return;
            }

            var reader = new StreamReader(File.OpenRead(path));

            var parser = new Parser();

            try
            {
                List<List<Card>> cards = parser.Parse(reader);
            }
            catch (Exception) {
                Console.Error.WriteLine("Invalid input file. Parsing error.");
                return;
            }
        }
    }
}
