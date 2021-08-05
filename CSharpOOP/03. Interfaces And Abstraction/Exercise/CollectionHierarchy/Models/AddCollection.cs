using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        private List<string> addCollection;

        public AddCollection()
        {
            this.addCollection = new List<string>();
        }

        public int Add(string item)
        {
            addCollection.Add(item);
            return addCollection.Count-1;
        }
    }
}
