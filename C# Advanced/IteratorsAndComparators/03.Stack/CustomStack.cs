using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> myCustomStack;

        private int pointer = -1;

        public CustomStack()
        {
            this.MyCustomStack = new List<T>();
        }

        public List<T> MyCustomStack
        {
            get { return this.myCustomStack; }
            private set { this.myCustomStack = value; }
        }

        public int Pointer
        {
            get { return this.pointer; }
            private set { this.pointer = value; }
        }


        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this.MyCustomStack.Add(element);
                this.Pointer++;
            }
        }

        public void Pop()
        {
            if (pointer < 0)
            {
                throw new InvalidOperationException("No elements");
            }
            this.MyCustomStack.RemoveAt(pointer);
            this.Pointer--;
        }


        public IEnumerator<T> GetEnumerator()
        {


            for (int i = pointer; i >= 0; i--)
            {
                yield return this.MyCustomStack[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
