﻿using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;
        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            this.models.Add(model);
        }
        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
        public IGun FindByName(string name)
        {
            var searchedGun = this.Models.FirstOrDefault(x => x.Name == name);
            return searchedGun;
        }

        
    }
}
