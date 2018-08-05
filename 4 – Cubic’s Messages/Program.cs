using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4___Cubic_s_Messages
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string inputString = Console.ReadLine();
                if (inputString == "Over!")
                {
                    break;
                }
                int num = int.Parse(Console.ReadLine());

                string pattern = @"^(\d+)([a-zA-Z]{" + num + @"})([^a-zA-Z]*)$";
                MatchCollection matches = Regex.Matches(inputString, pattern);
                List<int> numbers = new List<int>();

                foreach (Match match in matches)
                {
                    string code = match.Groups[2].ToString();
                    var numGroups = match.Groups[1].ToString() + match.Groups[3];
                    var onlyDigitsChars = numGroups.Where(Char.IsDigit).ToArray();

                    List<char> codesList = new List<char>();
                    foreach (var index in onlyDigitsChars)
                    {
                        int indexNum = int.Parse(index.ToString());
                        if (indexNum >= 0 && indexNum < code.Length)
                        {
                            codesList.Add(code[indexNum]);
                        }
                        else
                        {
                            codesList.Add(' ');
                        }
                    }
                    Console.WriteLine($"{code} == {string.Join("", codesList)}");
                }


            }


        }
    }
}
