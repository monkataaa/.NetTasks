using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,Student> studentsDict = new SortedDictionary<string, Student>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of dates")
                {
                    break;
                }

                List<string>inputData = input.Split(' ', ',').ToList();
                string userName = inputData[0];
                inputData.RemoveAt(0);
                Student someStudent = new Student(userName);
                someStudent.Dates = inputData.Select(x => DateTime.ParseExact(x, "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture)).ToList();
                List<DateTime> studentDates = inputData.Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)).ToList();





                if (studentsDict.ContainsKey(userName))
                {
                    foreach (var date in studentDates)
                    {
                        studentsDict[userName].Dates.Add(date);
                    }
                    
                }
                else
                {
                    studentsDict.Add(userName, someStudent);
                }

               

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of comments")
                {
                    break;
                }

                var inputData = input.Split('-');

                if (!studentsDict.ContainsKey(inputData[0]))
                {
                    continue;
                }
                
                

                    studentsDict[inputData[0]].Comments.Add(inputData[1]);
               

            }

            foreach (var student in studentsDict.Values)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Dates.OrderBy(x => x))
                {
               
                    Console.WriteLine($"-- {date.ToString($"dd")}/{date.ToString($"MM")}/{date.ToString($"yyyy")}" +
                                      $"");
                }
            }
        }

        public class Student
        {
            public string Name { get;  }
            public List<string> Comments { get; set; }
            public List<DateTime> Dates { get; set; }

            public Student(string name)
            {
                this.Name = name;
                Comments = new List<string>();
                Dates = new List<DateTime>();
            }



        }
    }
}
