using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }
        public override string ToString()
        {
            var classType = this.Value.GetType();
            var sb = new StringBuilder();

            sb.Append(string.Format("{0}: {1}", classType, this.Value));
            return sb.ToString();
        }
    }
}
