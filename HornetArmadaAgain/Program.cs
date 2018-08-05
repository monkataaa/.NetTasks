using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmadaAgain
{
    class Program
    {
        static void Main(string[] args)
        {

            long n = long.Parse(Console.ReadLine());
            Dictionary<string,long> legionsNamesAndActivity = new Dictionary<string, long>();
            Dictionary<string,Dictionary<string,long>> legionsSoldersTypeCount = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string [] inputData = Console.ReadLine().Split(new string[] {" = ", " -> ", ":"}, StringSplitOptions.RemoveEmptyEntries);

                long activity = long.Parse(inputData[0]);
                string legionName = inputData[1];
                string solderName = inputData[2];
                long solderCount = long.Parse(inputData[3]);

                if (!legionsNamesAndActivity.ContainsKey(legionName))
                {
                    legionsNamesAndActivity.Add(legionName,activity);
                    legionsSoldersTypeCount.Add(legionName,new Dictionary<string, long>());
                    legionsSoldersTypeCount[legionName].Add(solderName,solderCount);
                }
                else
                {
                    if (activity > legionsNamesAndActivity[legionName])
                    {
                        legionsNamesAndActivity[legionName] = activity;
                    }
                    if (!legionsSoldersTypeCount[legionName].ContainsKey(solderName))
                    {
                        legionsSoldersTypeCount[legionName].Add(solderName,0);
                    }

                    legionsSoldersTypeCount[legionName][solderName] += solderCount;
                }
               
            }
            string[] inputPrint = Console.ReadLine().Split('\\');

            if (inputPrint.Length > 1)
            {
                long activityToCheck = long.Parse(inputPrint[0]);
                string solderTypeToCheck = inputPrint[1];
                foreach (var legion in legionsSoldersTypeCount
                    .Where(x => x.Value.ContainsKey(solderTypeToCheck))
                    .OrderByDescending(x => x.Value[solderTypeToCheck]))
                {
                    if (legionsNamesAndActivity[legion.Key] <activityToCheck )
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[solderTypeToCheck]}");
                    }   
                }
            }
            else
            {
                string solderTypeToCheck = inputPrint[0];
                foreach (var legion in legionsSoldersTypeCount
                    .Where(x => x.Value.ContainsKey(solderTypeToCheck))
                    .OrderByDescending(x => legionsNamesAndActivity[x.Key]))
                {
                    Console.WriteLine($"{legionsNamesAndActivity[legion.Key]} : {legion.Key}");
                }
            }

        }
    }
}
