using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> participants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<decimal> zones = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
            List<long> originalCheckpoints = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            foreach (var driver in participants)
            {
                var checkpoints = originalCheckpoints.ToList();
                bool notFinished = false;
                int lastZone = 0;
                decimal fuel = (decimal)driver[0];

                for (int i = 0; i < zones.Count; i++)
                {
                    if (checkpoints.Count != 0 && checkpoints.Contains(i) && i == checkpoints[0])
                    {
                        fuel += zones[i];
                   //     checkpoints.RemoveAt(0);
                    }
                    else
                    {
                        fuel -= zones[i];
                    }

                    if (fuel <= 0)
                    {
                        notFinished = true;
                        lastZone = i;
                        break;
                    }

     
                }
                if (notFinished)
                {
                    Console.WriteLine($"{driver} - reached {lastZone}");  
                }
                else
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:F2}");
                }
             
            }

        }
    }
}
