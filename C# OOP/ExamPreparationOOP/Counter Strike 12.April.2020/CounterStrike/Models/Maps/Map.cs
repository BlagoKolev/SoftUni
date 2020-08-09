using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();

        }
        public string Start(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    this.terrorists.Add(player);
                }
                else
                {
                    this.counterTerrorists.Add(player);
                }
            }

            while (this.terrorists.Any(p => p.IsAlive == true) && this.counterTerrorists.Any(p => p.IsAlive == true))
            {
                StartBattle(this.terrorists, this.counterTerrorists);
                StartBattle(this.counterTerrorists, this.terrorists);
            }
            if (this.counterTerrorists.Any(p => p.IsAlive))
            {
                return "Counter Terrorist wins!";
            }
            else
            {
                return "Terrorist wins!";
            }

        }



        private void StartBattle(List<IPlayer> attakers, List<IPlayer> defenders)
        {
            var damage = 0;
            foreach (var attaker in attakers)
            {

                foreach (var defender in defenders)
                {
                    if (attaker.IsAlive == true)
                    {
                        if (defender.IsAlive == true)
                        {
                            damage = attaker.Gun.Fire();
                            defender.TakeDamage(damage);
                        }
                        
                    }
                   
                }
            }
        }
    }
}
