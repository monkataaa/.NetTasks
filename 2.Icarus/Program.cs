using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Icarus
{
    class Program
    {
        static void Main(string[] args)
        {

            var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int startIndex = int.Parse(Console.ReadLine());
            var damageIndexStepsArr = new int[3];
            damageIndexStepsArr[0] = 1;
            damageIndexStepsArr[1] = startIndex;
            string input = Console.ReadLine();
            while (input != "Supernova")
            {
                var inputData = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();



                string direction = inputData[0];
                int steps = int.Parse(inputData[1]);

                damageIndexStepsArr[2] = steps;

                if (direction == "right")
                {
                    ReverseToRIght(array, damageIndexStepsArr);
                }

                if (direction == "left")
                {
                    ReverseToLeft(array, damageIndexStepsArr);
                }



                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ",array));
            Console.ReadLine();
        }

        private static void ReverseToLeft(int[] array, int[] damageIndexStepsArr)
        {
           
                for (int i = damageIndexStepsArr[1] - 1; i >= 0; i--)
                {
                    if (damageIndexStepsArr[2] == 0)
                    {
                        break;
                    }
                    array[i] -= damageIndexStepsArr[0];
                    damageIndexStepsArr[2]--;
                    damageIndexStepsArr[1]--;
                   
                }
            

            if (array.Length == 1)
            {
                array[0] -= damageIndexStepsArr[0];
                return;
            }

            if (damageIndexStepsArr[2] > 0)
            {
                damageIndexStepsArr[0]++;
                damageIndexStepsArr[1] = array.Length;
                ReverseToLeft(array, damageIndexStepsArr);
            }
           
        }

        private static void ReverseToRIght(int[] array, int[] damageIndexStepsArr)
        {

           
                for (int i = damageIndexStepsArr[1] + 1; i < array.Length; i++)

            {
                    if (damageIndexStepsArr[2] == 0)
                    {
                        break;
                    }
                    array[i] -= damageIndexStepsArr[0];
                    damageIndexStepsArr[2]--;
                    damageIndexStepsArr[1]++;
              
                }



            if (array.Length == 1)
            {
                array[0] -= damageIndexStepsArr[0];
                return;
            }
         
         
            if (damageIndexStepsArr[2] > 0)
            {
                damageIndexStepsArr[0]++;
                damageIndexStepsArr[1] = 0;
                ReverseToRIght(array,  damageIndexStepsArr);
            }
                
        }
    }
}
