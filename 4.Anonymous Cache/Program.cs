using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Anonymous_Cache
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
           
                var results = new Dictionary<string, Dictionary<string, long>>();
                var cashDict = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {



                var inputData = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (inputData.Count == 1)
                {
                    string dataSet = inputData[0];

                    if (!results.ContainsKey(dataSet))
                    {
                        results.Add(dataSet, new Dictionary<string, long>());
                    }
                  //  xxxxxx[yyyyyy].Add(kkkkkkkk, llllllll);
                }

                if (inputData.Count > 1)
                {
                    string dataKey = inputData[0];
                    long dataSize = long.Parse(inputData[2]);
                    string dataSetToAdd = inputData[4];

                    if (!results.ContainsKey(dataSetToAdd))
                    {

                        if (!cashDict.ContainsKey(dataSetToAdd))
                        {
                            cashDict.Add(dataSetToAdd, new Dictionary<string, long>());
                        }
                        if (!cashDict[dataSetToAdd].ContainsKey(dataKey))
                        {
                            cashDict[dataSetToAdd].Add(dataKey,0);
                        }

                        cashDict[dataSetToAdd][dataKey] += dataSize;
                    }
                    else
                    {
                        if (!results[dataSetToAdd].ContainsKey(dataKey))
                        {
                            results[dataSetToAdd].Add(dataKey,0);
                        }
                        results[dataSetToAdd][dataKey] += dataSize;
                    }
                   


                    
                }

             input = Console.ReadLine();
            }

            TransferData(results, cashDict);
            PrintAll(results);
            Console.ReadLine();

        }

        private static void PrintAll(Dictionary<string, Dictionary<string, long>> results)
        {
            int count = 1;
            foreach (var data in results.OrderByDescending(x => x.Value.Values.Sum()))
            {
                if (count == 0)
                {
                    return;
                }
             
                long wholeSume = data.Value.Values.Sum();
                Console.WriteLine($"Data Set: {data.Key}, Total Size: {wholeSume}");
                foreach (var element in data.Value)
                {
                    Console.WriteLine($"$.{element.Key}");
                }
                count--;
            }
        }

        private static void TransferData(Dictionary<string, Dictionary<string, long>> results, Dictionary<string, Dictionary<string, long>> cashDict)
        {
            foreach (var data in results)
            {
                string dataKey = data.Key;

                if (cashDict.ContainsKey(dataKey))
                {
                    foreach (var elementKey in cashDict[dataKey])
                    {
                        string keyToCopy = elementKey.Key;
                        long longToCopy = elementKey.Value;
                      

                        if (!results[dataKey].ContainsKey(keyToCopy))
                        {

                     results[dataKey].Add(keyToCopy,longToCopy);
                        }
                    }
         
                }
            }
        }
    }
}
