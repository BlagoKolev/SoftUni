using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => this.models as IReadOnlyCollection<IPresent>;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            IPresent searchedPresent = this.Models.FirstOrDefault(x => x.Name == name);
            return searchedPresent;
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }
    }
}
