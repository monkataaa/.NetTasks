using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _07.Andrey_and_Billiard
{
    class Program
    {
        static void Main(string[] args)
        {

            int entitiesAmount = int.Parse(Console.ReadLine());
            int startCount = 0;
            var productsAndPrises = new Dictionary<string,double>();
            while (startCount<entitiesAmount)
            {
                var input = Console.ReadLine().Split('-').ToList();
                var product = input[0];
                var prise = double.Parse(input[1]);
                if (!productsAndPrises.ContainsKey(product))
                {
                    productsAndPrises.Add(product,0.0);
                }

                productsAndPrises[product] = prise;

                startCount++;
            }

            //foreach (var item in productsAndPrises)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}


            List<Client> clientAndOrdersList = new List<Client>();
            double totalBill = 0.0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of clients")
                {
                    break;
                }

                var clientOrdersinput = input.Split('-', ',').ToList();


                string clientName = clientOrdersinput[0];
                string clientProduct = clientOrdersinput[1];
                double clientProductQuantity = double.Parse(clientOrdersinput[2]);

                if (!productsAndPrises.ContainsKey(clientProduct))
                {
                    continue;
                }

                Client SomeClient = new Client();
                if (clientAndOrdersList.Any(n => n.Name == clientName))
                {

                    Client existingClient = clientAndOrdersList.First(x => x.Name == clientName);

                    if (existingClient.ProductAndQuantity.ContainsKey(clientProduct))
                    {

                        existingClient.ProductAndQuantity[clientProduct] += clientProductQuantity;
                        existingClient.Bill += (existingClient.ProductAndQuantity[clientProduct] * productsAndPrises[clientProduct]);
                        //clientAndOrdersList.Where(n => n.Name == clientName && n.Product == clientProduct)
                        //    .ToList().ForEach(p => p.Bill += (clientProductQuantity* productsAndPrises[clientProduct]));

                    }
                }
                else
                {
                    SomeClient.Name = clientName;
       
                    SomeClient.ProductAndQuantity = new Dictionary<string, double>();
                   // SomeClient.ProductAndQuantity.Add(clientProduct, clientProductQuantity);
                    SomeClient.ProductAndQuantity.Add("birichka", 3.1565);
                    clientAndOrdersList.Add(SomeClient);
                }

                Console.WriteLine();
                SomeClient.Bill = SomeClient.ProductAndQuantity[clientProduct] * productsAndPrises[clientProduct];
                
                totalBill += SomeClient.Bill;
              

            }

            foreach (var client in clientAndOrdersList.OrderBy(x => x.Name))
            {
                Console.WriteLine(client.Name);
                foreach (var product in client.ProductAndQuantity)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }
                
                Console.WriteLine($"Bill: {client.Bill:F2}");
            }
            Console.WriteLine("Total bill: {0:F2}",totalBill);

        }

        public class Client
        {
            public string Name { get; set; }
            public Dictionary <string, double> ProductAndQuantity { get; set; }
            public double Quantity { get; set; }
            public double Bill { get; set; }
        }
    }
}
