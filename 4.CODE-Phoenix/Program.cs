using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.CODE_Phoenix
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            var results = new Dictionary<string, List<string>>();

            while (input != "Blaze it!")
            {



                var inputData = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string creature = inputData[0];
                string squadMate = inputData[1];

 

                if (creature == squadMate)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!results.ContainsKey(creature))
                {
                    results.Add(creature,new List<string>());
                }
                if (!results[creature].Contains(squadMate)  )
                {
                    results[creature].Add(squadMate);

                }
               

                input = Console.ReadLine();
            }

            foreach (var creature in results)
            {
                string creatureNameOriginal = creature.Key;
              
             
                for (int i = 0; i < results[creatureNameOriginal].Count; i++)
                {
                    string squadMateOriginal = results[creatureNameOriginal][i];

                    if (results.ContainsKey(squadMateOriginal) && results[squadMateOriginal].Contains(creatureNameOriginal))
                    {
                       
                        results[squadMateOriginal].Remove(creatureNameOriginal);
                        results[creatureNameOriginal].Remove(squadMateOriginal);
                   
                    }
                
 
                }



            }

            foreach (var creatureKey in results.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{creatureKey.Key} : {creatureKey.Value.Count}");
            }

            input = Console.ReadLine();

        }
    }
}
