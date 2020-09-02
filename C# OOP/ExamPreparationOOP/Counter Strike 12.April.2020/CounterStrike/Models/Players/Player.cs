﻿using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }
        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                if (this.Armor >= points)
                {
                    this.Armor -= points;
                    points = 0;
                }
                else
                {
                    points -= this.Armor;
                    this.Armor = 0;
                }
            }

            if (points > 0)
            {
                if (this.Health <= points)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= points;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}")
            .AppendLine($"--Health: {this.Health}")
            .AppendLine($"--Armor: {this.Armor}")
            .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}