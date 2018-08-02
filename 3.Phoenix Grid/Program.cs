using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Phoenix_Grid
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "ReadMe")
                {
                    break;
                }

                var inputData = input.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToList();
                bool lenghtCheck = true;
                bool palindromeCheck = true;
                foreach (var frase in inputData)
                {
                    if (!(frase.Length == 3))
                    {
                        
                        lenghtCheck = false;
                    }

                   
                }

                if (lenghtCheck)
                {
                    PalindromChecker(inputData);
                }
                else
                {
                    Console.WriteLine("NO");
                }
                

            }
        }

        private static void PalindromChecker(List<string> inputData)
        {
            string neshto = String.Join("", inputData);
          //  Console.WriteLine("neshto e "+neshto);
            bool isPalidr = true;
            for (int i = 0; i < neshto.Length/2; i++)
            {
                if (!(neshto[i] == neshto[neshto.Length-1-i]))
                {
                    isPalidr = false;
                }
            }
            if (neshto.Contains(' ') || neshto.Contains('_'))
            {
                Console.WriteLine("NO");
                return;
            }
            if (isPalidr)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


           
             
                  
                
            
        }
    }
}
