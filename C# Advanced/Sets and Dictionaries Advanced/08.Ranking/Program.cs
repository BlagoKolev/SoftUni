using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestWithPass = new Dictionary<string, string>();

            while (true)
            {
                var interviewArgs = Console.ReadLine()
               .Split(new char[] { ':' }
               , StringSplitOptions
               .RemoveEmptyEntries);

                if (interviewArgs[0] == "end of contests")
                {
                    break;
                }

                var contestName = interviewArgs[0];
                var contentsPass = interviewArgs[1];



                if (!contestWithPass.ContainsKey(contestName))
                {
                    contestWithPass[contestName] = contentsPass;
                }
            }

            var userWithPoints =
                new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var submissionArgs = Console.ReadLine()
                    .Split(new string[] { "=>" }
                    , StringSplitOptions
                    .RemoveEmptyEntries);

                if (submissionArgs[0] == "end of submissions")
                {
                    break;
                }

                var contest = submissionArgs[0];
                var pass = submissionArgs[1];
                var username = submissionArgs[2];
                var points = double.Parse(submissionArgs[3]);

                if (contestWithPass.ContainsKey(contest))
                {
                    if (contestWithPass[contest] == pass)
                    {
                        if (!userWithPoints.ContainsKey(username))
                        {
                            userWithPoints[username] = new Dictionary<string, double>();
                        }

                        if (!userWithPoints[username].ContainsKey(contest))
                        {
                            userWithPoints[username][contest] = points;
                        }

                        else
                        {
                            if (userWithPoints[username][contest] < points)
                            {
                                userWithPoints[username][contest] = points;
                            }
                        }

                    }
                }
            }

            var bestStudent = string.Empty;
            var maxPoint = 0.0;

            foreach (var student in userWithPoints)
            {
                var studentPoints = 0.0;
                foreach (var points in student.Value)
                {
                    studentPoints += points.Value;
                }
                if (studentPoints > maxPoint)
                {
                    maxPoint = studentPoints;
                    bestStudent = student.Key;
                }
            }

            Console.WriteLine("Best candidate is {0} with total {1} points.", bestStudent, maxPoint);

            Console.WriteLine("Ranking:");
            foreach (var student in userWithPoints)
            {
                Console.WriteLine(student.Key);
                foreach (var contests in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", contests.Key, contests.Value);
                }
            }
        }
    }
}
