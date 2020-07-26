using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models { get { return this.models; } }


        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }
        public IDecoration FindByType(string type)
        {
            var searchedDecoration = this.Models.FirstOrDefault(x => x.GetType().Name == type);
            return searchedDecoration;
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }
    }


}
