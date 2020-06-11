using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> myList;
        private int pointer = 0;

        public ListyIterator(params T[] array)
        {
            this.myList = new List<T>(array);
        }

        public int Pointer
        {
            get { return this.pointer; }
            private set { this.pointer = value; }
        }

        public bool Move()
        {
            if (this.Pointer >= this.myList.Count-1)
            {
                return false;
            }
            this.Pointer++;
            return true;
        }

        public bool HasNext()
        {
            if (this.pointer >= this.myList.Count - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if (this.myList.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(this.myList[this.Pointer]);
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.myList.Count; i++)
            {
                yield return this.myList[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
