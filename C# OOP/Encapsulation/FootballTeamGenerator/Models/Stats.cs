using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Common;
namespace FootballTeamGenerator
{
    public class Stats
    {
        private const double STATS_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.SkillLevel = skillLevel;
        }

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(GlobalConstant.InvlidStatException, "Endurance"));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(GlobalConstant.InvlidStatException, "Sprint"));
                }
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(GlobalConstant.InvlidStatException, "Dribble"));
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(GlobalConstant.InvlidStatException, "Passing"));
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(GlobalConstant.InvlidStatException, "Shooting"));
                }
                this.shooting = value;
            }
        }

        private double skillLevel;

        public double SkillLevel
        {
            get { return this.skillLevel; }
            private set
            {
                this.skillLevel = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STATS_COUNT;

            }
        }
    }
}
