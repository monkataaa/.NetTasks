using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputList = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            bool check = true;
            List<int> skipAttacingEllements = new List<int>();
            while (check)
            {
                if (inputList.Count == 1)
                {
                    Console.WriteLine();
                    check = false;
                    break;
                }
              
                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i] >= inputList.Count)
                    {
                        inputList[i] = inputList[i] % inputList.Count;
                    }
                    //  Console.WriteLine(String.Join(" ",inputList));

                }

                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList.Count == 1)
                    {
                      //  Console.WriteLine();
                        check = false;
                        break;
                    }
                    if (skipAttacingEllements.Contains(i))
                    {
                        continue;
                    }
                    int attackerIndex = i;
                    int targetIndex = inputList[i];
                    int tempResult = Math.Abs(attackerIndex - targetIndex);

                    if (attackerIndex == targetIndex)
                    {
                        Console.WriteLine($"{attackerIndex} performed harakiri");
                        
                        for (int j = i; j < inputList.Count; j++)
                        {
                            skipAttacingEllements.Add(j);
                        }
                    }
                    else
                    {
                        if (tempResult % 2 == 0)
                        {
                            skipAttacingEllements.Add(targetIndex);
                          //  Console.WriteLine("attacer wins");
                               Console.WriteLine( $"{ attackerIndex} x { targetIndex} -> {attackerIndex} wins");
                        }
                        else
                        {
                            skipAttacingEllements.Add(attackerIndex);
                            Console.WriteLine($"{ attackerIndex} x { targetIndex} -> {targetIndex} wins");
                        //    Console.WriteLine("target wins");
                        }
                    }


                 
                }

                foreach (var element in skipAttacingEllements.OrderByDescending(x => x))
                {
                    if (inputList.Count<=element)
                    {
                        continue;
                    }
                    inputList.RemoveAt(element);
               
                    //if (inputList.Count == 1)
                    //{
                    //    Console.WriteLine();
                    //    check = false;
                    //    break;
                    //}
                }
                skipAttacingEllements.Clear();
            }

          


            
            Console.ReadLine();
        }
    }
}
