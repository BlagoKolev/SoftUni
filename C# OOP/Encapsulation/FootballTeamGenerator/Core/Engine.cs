using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Models;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            

            while (true)
            {
                try
                {
                    var command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    Player player = null;
                    Stats stats = null;

                    if (command.StartsWith("Team"))
                    {
                        var teamArgs = command.Split(new char[] { ';' });
                        var teamName = teamArgs[1];
                       var team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (command.StartsWith("Add"))
                    {
                        var playerArgs = command.Split(new char[] { ';' });
                        var teamName = playerArgs[1];
                        var playerName = playerArgs[2];
                        var endurance = int.Parse(playerArgs[3]);
                        var sprint = int.Parse(playerArgs[4]);
                        var dribble = int.Parse(playerArgs[5]);
                        var passing = int.Parse(playerArgs[6]);
                        var shooting = int.Parse(playerArgs[7]);

                        CheckIsTeamExist(teamName);

                        stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        player = new Player(playerName, stats);
                        var currentTeam = this.teams.Where(x => x.Name == teamName).FirstOrDefault();
                        currentTeam.Add(player);
                    }
                    else if (command.StartsWith("Remove"))
                    {
                        var removeArgs = command.Split(new char[] { ';' });
                        var teamName = removeArgs[1];
                        var playerName = removeArgs[2];
                        var currentTeam = teams.Where(x => x.Name == teamName).FirstOrDefault();
                        currentTeam.Remove(playerName);
                    }
                    else if (command.StartsWith("Rating"))
                    {
                        var ratingArgs = command.Split(new char[] { ';' });
                        var teamName = ratingArgs[1];

                        CheckIsTeamExist(teamName);
                       
                        var currentTeam = this.teams.Where(x => x.Name == teamName).FirstOrDefault();
                        Console.WriteLine("{0} - {1}", currentTeam.Name, Math.Round(currentTeam.Rating(teamName)));
                    }

                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }
            }


        }
       private void CheckIsTeamExist(string teamName)
        {
            if (!teams.Any(x => x.Name == teamName))
            {
                throw new ArgumentException(string.Format(GlobalConstant.MissingTeamException, teamName));
            }
        }
    }
}
