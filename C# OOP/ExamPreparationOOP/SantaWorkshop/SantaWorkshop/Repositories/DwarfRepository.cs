using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this.models as IReadOnlyCollection<IDwarf>;
        

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            IDwarf searchedDwarf = this.Models.FirstOrDefault(x => x.Name == name);
            return searchedDwarf;
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}
