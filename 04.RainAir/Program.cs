using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RainAir
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var allFlights = new Dictionary<string, List<string>>();
            while (input != "I believe I can fly!")
            {



                var inputData = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string customerName = inputData[0];
                string check = inputData[1];

                if (!(check == "="))
                {
                    var customerFlights = inputData.ToList();
                    customerFlights.RemoveAt(0);


                    if (!allFlights.ContainsKey(customerName))
                    {
                        allFlights.Add(customerName, new List<string>());
                    }
                    foreach (var flight in customerFlights)
                    {
                        allFlights[customerName] .Add(flight);
                    }
                    
                }
                else
                {
                    string customer2 = inputData[2];

                   allFlights[customerName].Clear();
                    List<string> listToCopy = allFlights[customer2].ToList();
                    allFlights[customerName] =  listToCopy;

                }


                input = Console.ReadLine();
            }

            foreach (var customer in allFlights.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
            {
                string allCustomerFlights = String.Join(", ", customer.Value. Select(int.Parse).OrderBy(x => x));
                Console.WriteLine($"#{customer.Key} ::: {allCustomerFlights}");
             }
            Console.ReadLine();
        }
    }
}
