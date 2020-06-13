using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class ListyIterator<T>
    {
        private readonly List<T> myList;
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



    }
}
