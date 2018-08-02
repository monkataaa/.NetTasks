using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demonsList = new List<Demon>();
            var inputData = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string k = "k";
            char l = k[0];
            int n = (l);
          //  Console.WriteLine(n);
            string healthPatern = @"[a-zA-Z]";
            string damagePatern = @"[-+\d\.]+";
            string signsPatern = @"[*\/]";

            foreach (var input in inputData)
            {

                Demon someDemon = new Demon();
                long tempHealth = 0;
                MatchCollection matchesHealth = Regex.Matches(input, healthPatern);
         
                foreach (Match match in matchesHealth)
                {
                    string strMatch = match.Value;
                    char chMatch = strMatch[0];
                    long intMatch = chMatch;
                    tempHealth += intMatch;
                    //Console.WriteLine(intMatch);
                }
                someDemon.Name =  input.Trim();
                someDemon.Health = tempHealth;
                demonsList.Add(someDemon);

                MatchCollection matchesDamage = Regex.Matches(input, damagePatern);
                foreach (Match match in matchesDamage)
                {
                    if (match.Value == "-" || match.Value == "+")
                    {
                        continue;
                    }
                    someDemon.Damage += decimal.Parse(match.Value);
                  //  Console.WriteLine("someDemonDamage is "+ someDemon.Damage);
                }

                MatchCollection matchesSigns = Regex.Matches(input, signsPatern);
                foreach (Match match in matchesSigns)
                {
                    string sign = match.Value;
                    if (sign == "*")
                        someDemon.Damage *= 2;
                    if (sign == "/")
                        someDemon.Damage /= 2;
         //           Console.WriteLine("someDemonDamage is " + someDemon.Damage);
                }

            }

            foreach (var demon in demonsList.OrderBy(x => x.Name))
            {
               
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }

            Console.ReadLine();
        }

        public class Demon
        {
            public string Name { get; set; }
            public long Health { get; set; }
            public decimal Damage { get; set; }
        }
    }
}
