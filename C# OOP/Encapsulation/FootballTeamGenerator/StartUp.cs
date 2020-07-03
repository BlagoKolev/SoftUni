using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Models;
using FootballTeamGenerator.Core;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
