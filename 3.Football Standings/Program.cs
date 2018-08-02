using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Football_Standings
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string input = Console.ReadLine();
            string patternTeams = $@"([{key}]+)(.+?)([{key}]+)";
            string patternScores = @"([\d]+):([\d]+)";

            var teamsPoints = new Dictionary<string, long>();
            var topScored = new Dictionary<string, long>();
            

            while (input != "final")
            {


                MatchCollection matchesTeams = Regex.Matches(input, patternTeams);
                List<string> teams = new List<string>();

                foreach (Match match in matchesTeams)
                {
                    var teamCh = match.Groups[2].Value.ToUpper().ToCharArray();
                    Array.Reverse(teamCh);
                    string team = String.Join("",teamCh);
                    teams.Add(team);
                }
                string teamA = teams[0];
                string teamB = teams[1];
              

                MatchCollection matchesScores = Regex.Matches(input, patternScores);

                long scoreA = 0;
                long scoreB = 0;
                foreach (Match match in matchesScores)
                {
                    string scoreAstr = match.Groups[1].ToString();
                     scoreA = long.Parse(scoreAstr);

                    string scoreBstr = match.Groups[2].ToString();
                     scoreB = long.Parse(scoreBstr);
                }

                CalculatePoints(teamA, teamB, scoreA, scoreB, teamsPoints);
                CalculateTopScores(teamA, teamB, scoreA, scoreB,topScored);
                input = Console.ReadLine();
            }
            long count = 1;
            Console.WriteLine("League standings:");
           foreach (var team in teamsPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {team.Key} {team.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");
            int scoreCount = 0;
            foreach (var score in topScored.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (scoreCount == 3)
                {
                    break;
                }
                Console.WriteLine($"- {score.Key} -> {score.Value}");
                scoreCount++;
            }
            Console.ReadLine();
        }

        private static void CalculateTopScores(string teamA, string teamB, long scoreA, long scoreB, Dictionary<string, long> topScored)
        {
            if (!topScored.ContainsKey(teamA))
            {
                topScored.Add(teamA, 0);
            }
            if (!topScored.ContainsKey(teamB))
            {
                topScored.Add(teamB, 0);
            }

            topScored[teamA] += scoreA;
            topScored[teamB] += scoreB;
        }

        private static void CalculatePoints(string teamA, string teamB, long scoreA, long scoreB, Dictionary<string, long> teamsPoints)
        {
            if (!teamsPoints.ContainsKey(teamA))
            {
                teamsPoints.Add(teamA, 0);
            }

            if (!teamsPoints.ContainsKey(teamB))
            {
                teamsPoints.Add(teamB, 0);
            }

            if (scoreA > scoreB)
            {

                teamsPoints[teamA]+=3;
            }
            if (scoreA < scoreB)
            {

                teamsPoints[teamB] += 3;
            }
            if (scoreA == scoreB)
            {

                teamsPoints[teamA] += 1;
                teamsPoints[teamB] += 1;
            }
        }
    }
}
