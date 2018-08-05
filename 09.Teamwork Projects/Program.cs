using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _09.Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {   

            Dictionary<string,Teams> usersTeamsDict = new Dictionary<string, Teams>();
            int gropupCount = int.Parse(Console.ReadLine());
            List<string> massages = new List<string>();

            for (int i = 0; i < gropupCount; i++)
            {
                string[] CreatorAndTeamArray = Console.ReadLine().Split('-');
                string creator = CreatorAndTeamArray[0];
                string team = CreatorAndTeamArray[1];

                if (usersTeamsDict.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} was already created!");
                    //massages.Add($"Team {team} was already created!");
                    continue;
                }
                if (usersTeamsDict.Values.Any(n => n.Members.Contains(creator)))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                  //  massages.Add($"{creator} cannot create another team!");
                    continue;
                }
                usersTeamsDict.Add(team,new Teams(){CreatorName = creator, Members = new List<string>(){creator}});
               // massages.Add($"Team {team} has been created by {creator}!");
                Console.WriteLine($"Team {team} has been created by {creator}!");
            }
            
            //foreach (var team in usersTeamsDict)
            //{
            //    Console.WriteLine($"Team {team.Value.TeamName} has been created by {team.Value.Members[0]}!");
            //}


            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of assignment")
                {
                 break;   
                }

                string[] inputData = input.Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                string userToJoin = inputData[0];
                string teamToJoin = inputData[1];

                if (!usersTeamsDict.ContainsKey(teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                 //   massages.Add($"Team {teamToJoin} does not exist!");
                    continue;
                    
                }

                if (usersTeamsDict.Values.Any(n => n.Members.Contains(userToJoin)))
                {
                    Console.WriteLine($"Member {userToJoin} cannot join team {teamToJoin}!");
                   // massages.Add($"Member {userToJoin} cannot join team {teamToJoin}!");
                    continue;
                }
              
                usersTeamsDict[teamToJoin].Members.Add(userToJoin);

            }
    //        Console.WriteLine(string.Join(Environment.NewLine, massages));


            foreach (var team in usersTeamsDict.Values.Where(x => x.Members.Count>1).OrderByDescending(x => x.Members.Count).ThenBy(n => n))
            {
                var myKey = usersTeamsDict.FirstOrDefault(x => x.Value==team).Key;
                Console.WriteLine($"{myKey}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var group in team.Members.Where(x => x!=team.CreatorName).OrderBy(n => n))
                {
                    
                    Console.WriteLine($"-- {string.Join(Environment.NewLine,group)}");
                }
            }
            Console.WriteLine("Teams to disband:");

            foreach (var team in usersTeamsDict.Values.Where(x =>x.Members.Count==1))
            {
                var myKey = usersTeamsDict.FirstOrDefault(x => x.Value == team).Key;
                Console.WriteLine(myKey);
            }

        }

        public class Teams
        {
            public string CreatorName { get; set; }
            public List<string> Members { get; set; }
        }
    }
}
