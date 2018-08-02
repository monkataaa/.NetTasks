using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Trophon_the_Grumpy_Cat
{
    class Program
    {
        static void Main(string[] args)
        {


            var priceRatings = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            var entryPoint = int.Parse(Console.ReadLine());
            decimal entryPointValue = priceRatings[entryPoint];
           // Console.WriteLine(entryPointValue);
            string typeOfItems = Console.ReadLine();
            string priceRaitingNEgativePozitiveAll = Console.ReadLine(); 



            var leftPartArr = new List<decimal>();
            for (int i = 0; i < entryPoint; i++)
            {
                leftPartArr.Add(priceRatings[i]);
            }

            var rightPart = new List<decimal>();
            for (int i = entryPoint+1; i < priceRatings.Length; i++)
            {
                rightPart.Add(priceRatings[i]);
            }
            //Console.WriteLine(String.Join(" ", leftPartArr));
            //Console.WriteLine(String.Join(" ", rightPart));
            //Console.WriteLine(" entrypontValye e " + entryPointValue);
            decimal leftSume = CalculatePartSum(typeOfItems, priceRaitingNEgativePozitiveAll, entryPointValue, leftPartArr);
            decimal rightSum = CalculatePartSum(typeOfItems,priceRaitingNEgativePozitiveAll, entryPointValue, rightPart);

            if (leftSume >= rightSum)
            {
                Console.WriteLine($"Left - {leftSume}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
            



            Console.ReadLine();
        }

        private static decimal CalculatePartSum(string typeOfItems, string priceRaitingNEgativePozitiveAll, decimal entryPointValue, List<decimal> part
            )
        {
            if (priceRaitingNEgativePozitiveAll == "positive")
            {
                part = part.Where(x => x > 0).ToList();
            }
            if (priceRaitingNEgativePozitiveAll == "negative")
            {
                part = part.Where(x => x < 0).ToList();
            }


            decimal sum = 0;
            if (typeOfItems == "cheap")
            {
                sum = part.Where(x => x < entryPointValue).Sum();
            }

            if (typeOfItems == "expensive")
            {
                sum = part.Where(x => x > entryPointValue).Sum();
            }
          //  Console.WriteLine("sum e "+ sum);

            return sum;
        }
    }
}
