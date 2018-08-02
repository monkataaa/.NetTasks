using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {

            string surfacePattern = @"^[^a-zA-Z\d]+$";
            string mantlePattern = @"^[\d_]+$";
            string corePattern = @"^([^a-zA-Z\d]+)([\d_]+)([a-zA-Z]+)([\d_]+)([^a-zA-Z\d]+)$";

            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            string line3 = Console.ReadLine();
            string line4 = Console.ReadLine();
            string line5 = Console.ReadLine();


            bool line1check = Regex.IsMatch(line1, surfacePattern);
            bool line2check = Regex.IsMatch(line2, mantlePattern);
            bool line3check = Regex.IsMatch(line3, corePattern);
            string core = Regex.Match(line3, corePattern).Groups[3].ToString();
    
            bool line4check = Regex.IsMatch(line4, mantlePattern);
            bool line5check = Regex.IsMatch(line5, surfacePattern);

            if (line1check
                && line2check
                && line3check
                && line4check
                && line5check)
            {
                Console.WriteLine("Valid");
               // Console.WriteLine("core is "+core);
                Console.WriteLine(core.Length);
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            Console.ReadLine();
        }
    }
}
