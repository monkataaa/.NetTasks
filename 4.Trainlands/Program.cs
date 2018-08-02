using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            var trains = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "It's Training Men!")
            {



                var inputData = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string trainName = inputData[0];
                string separator = inputData[1];
             
                if (separator == "->")
                    if (inputData.Count > 3 )
                    {
                        string wagonName = inputData[2];
                        int wagonPower = int.Parse(inputData[4]);
                        CreateTrain(trainName,wagonName,wagonPower,trains);
                    }
                    else
                    {
                        string otherTrainName = inputData[2];
                        CopyAndRemove( trainName,  otherTrainName,  trains);
                    }

                if (separator == "=")
                {
                    string otherTrainName = inputData[2];
                    CopyPaste(trainName, otherTrainName, trains);
                }

                input = Console.ReadLine();
            }
      
            PrintAll(trains);
            Console.ReadLine();

        }

        private static void PrintAll(Dictionary<string, Dictionary<string, int>> trains)
        {
            foreach (var train in trains.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Values.Count))
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach (var wagon in train.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }

        private static void CopyPaste(string trainName, string otherTrainName, Dictionary<string, Dictionary<string, int>> trains)
        {

         
            if (trains.ContainsKey(trainName))
            {
                trains[trainName] = trains[otherTrainName];

            }
            else
            {
                trains.Add(trainName, new Dictionary<string, int>());
                trains[trainName] = trains[otherTrainName];
               
            }

        }

        private static void CopyAndRemove(string trainName, string otherTrainName,  Dictionary<string, Dictionary<string, int>> trains)
        {
         

            if (trains.ContainsKey(trainName))
            {
                foreach (var wagon in trains[otherTrainName])
                {
                    trains[trainName].Add(wagon.Key,wagon.Value);
                }
                
                trains.Remove(otherTrainName);
            }
            else
            {
                trains.Add(trainName,new Dictionary<string, int>());
                trains[trainName] = trains[otherTrainName];
                trains.Remove(otherTrainName);
            }
        }

        private static void CreateTrain(string trainName, string wagonName,  int wagonPower, Dictionary<string, Dictionary<string, int>> trains )
        {
        
            if (!trains.ContainsKey(trainName))
            {
                trains.Add(trainName, new Dictionary<string, int>());
            }
            trains[trainName].Add(wagonName,wagonPower);
            
        }
    }
}
