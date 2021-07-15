using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
