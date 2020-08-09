using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            switch (type)
            {
                case "Pistol": gun = new Pistol(name, bulletsCount); break;
                case "Rifle": gun = new Rifle(name, bulletsCount); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var currentGun = this.guns.Models.FirstOrDefault(g => g.Name == gunName);
            if (currentGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            switch (type)
            {
                case "Terrorist": player = new Terrorist(username, health, armor, currentGun); break;
                case "CounterTerrorist": player = new CounterTerrorist(username, health, armor, currentGun); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.players.Models.OrderBy(n => n.GetType().Name).ThenByDescending(h => h.Health).ThenBy(x => x.Username))
            {
                sb.AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var alivePlayers = this.players.Models.ToList();
           return this.map.Start(alivePlayers);
        }
    }
}
