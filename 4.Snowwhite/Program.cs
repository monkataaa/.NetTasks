using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Snowwhite> resultList  = new List<Snowwhite>();
            string input = Console.ReadLine();
            bool colorCheck = true;
            string mostUsedColer = "";

            while (input != "Once upon a time")
            {



                var inputData = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string dwarfName = inputData[0];
                string dwarfHatColor = inputData[1];
                int dwarfPhysics = int.Parse(inputData[2]);

                if (!resultList.Any(x => x.Name == dwarfName))
                {
                    Snowwhite someSnowwhite = new Snowwhite();
                    someSnowwhite.Name = dwarfName;
                    someSnowwhite.Color = dwarfHatColor;
                    someSnowwhite.Physics = dwarfPhysics;

                    resultList.Add(someSnowwhite);
                    
                }
                else
                {

                    if (resultList.Any(x => x.Name == dwarfName))
                    {
                        Snowwhite existing = resultList.First(x => x.Name == dwarfName);
                        if (existing.Color == dwarfHatColor)
                        {
                            if (existing.Physics < dwarfPhysics)
                            {
                                existing.Physics = dwarfPhysics;
                                existing.colorCount += 1;
                                colorCheck = false;
                            }
                           
                        }
                        else
                        {
                            Snowwhite newSnowWhite = new Snowwhite();
                            newSnowWhite.Name = dwarfName;
                            newSnowWhite.Color = dwarfHatColor;
                            newSnowWhite.Physics = dwarfPhysics;
                            resultList.Add(newSnowWhite);
                        }
                        
                    }
                    
                }

               

                input = Console.ReadLine();
            }
            int snowValue = resultList[0].Physics;
            bool sameValueCheck = true;

           foreach (var ex in resultList.OrderByDescending(x => x.colorCount))
           {
               mostUsedColer = ex.Color;
                break;
               
           }

            foreach (var snowWhite in resultList)
            {
                int temp = snowWhite.Physics;
                if (snowValue != temp)
                {
                    sameValueCheck = false;
                }

            }
            if (sameValueCheck && colorCheck)
            {
                foreach (var snowWhite in resultList)
                {

                    Console.WriteLine($"({snowWhite.Color}) {snowWhite.Name} <-> {snowWhite.Physics}");
                }
            }
            else
            {
                if (colorCheck)
                {
                    foreach (var snowWhite in resultList.OrderByDescending(x => x.Physics))
                    {

                        Console.WriteLine($"({snowWhite.Color}) {snowWhite.Name} <-> {snowWhite.Physics}");
                    }
                }
                else
                {

                    foreach (var snowWhite in resultList.OrderByDescending(x => x.Physics).ThenByDescending(x => x.Color == mostUsedColer))
                    {
                     
                        Console.WriteLine($"({snowWhite.Color}) {snowWhite.Name} <-> {snowWhite.Physics} ");
                    }
                }
            }

         
         

            Console.ReadLine();
        }

        public class Snowwhite
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }
            public int colorCount { get; set; }
            public int mostUsedColor { get; set; }

             
        }

    }
}
