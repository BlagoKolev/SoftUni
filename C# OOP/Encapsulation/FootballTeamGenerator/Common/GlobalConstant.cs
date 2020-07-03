using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Common
{
    static class GlobalConstant
    {
        public const string InvlidStatException = "{0} should be between 0 and 100.";
        public const string InvalidNameException = "Name should not be empty.";
        public const string MissingTeamException = "Team {0} does not exist.";
        public const string MissingPlayerException = "Player {0} is not in {1} team.";
    }
}
