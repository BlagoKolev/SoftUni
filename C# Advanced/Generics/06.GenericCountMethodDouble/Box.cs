using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Box<T> where T : IComparable
    {
        private List<T> myList;

        public Box()
        {
            this.MyList = new List<T>();
        }

        public List<T> MyList
        {
            get { return this.myList; }
            private set { this.myList = value; }
        }

        public int FindBiggerElements(List<T> myList, T element)
        {
            var count = 0;

            foreach (var item in myList)
            {
                if (element.CompareTo(item) == -1)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
