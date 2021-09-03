using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models { get; private set; } = new List<IEgg>();

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
            this.Models = eggs;
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (this.eggs.Contains(model))
            {
                this.eggs.Remove(model);
                this.Models = this.eggs;
                return true;
            }

            return false;
        }
    }
}
