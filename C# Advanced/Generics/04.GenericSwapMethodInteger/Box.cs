using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        private List<T> value;

        public Box(List<T> value)
        {
            this.Value = value;
        }

        public List<T> Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public List<T> SwapElements<T>(List<T> someList, int index1, int index2)
        {
            var helperVariable = someList[index1];
            someList[index1] = someList[index2];
            someList[index2] = helperVariable;
            return someList;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Value)
            {
                var type = item.GetType();
                sb.AppendLine(string.Format("{0}: {1}", type, item));
            }
            return sb.ToString();
        }
    }
}
