using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class MyList : IAdd, IRemove, IMyList
    {
        private List<string> myList;
        public MyList()
        {
            this.myList = new List<string>();
        }
        public int Used { get { return this.myList.Count; } }

        public int Add(string item)
        {
            this.myList.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            if (this.myList.Count > 0)
            {
                string itemToRemove = this.myList[0];
                this.myList.RemoveAt(0);
                return itemToRemove;
            }

            return default;
        }
    }
}
