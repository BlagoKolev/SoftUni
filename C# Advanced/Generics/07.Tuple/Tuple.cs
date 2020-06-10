using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 firstItem, T2 secondItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
        }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public override string ToString()
        {

            var result = Item1 + " -> " + Item2;
            return result;
        }
    }
}
