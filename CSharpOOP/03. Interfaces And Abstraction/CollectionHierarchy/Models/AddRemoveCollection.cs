using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> addRemoveCollection;
        public AddRemoveCollection()
        {
            this.addRemoveCollection = new List<string>();
        }
        public int Add(string item)
        {
            this.addRemoveCollection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            if (this.addRemoveCollection.Count > 0)
            {
                string itemToRemove = this.addRemoveCollection[this.addRemoveCollection.Count - 1];
                this.addRemoveCollection.RemoveAt(this.addRemoveCollection.Count - 1);
                return itemToRemove;
            }
            return default;
        }
    }
}
