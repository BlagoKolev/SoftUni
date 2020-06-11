using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndcomparators
{
    public class Lake : IEnumerable<int>
    {

        private List<int> stones;

        public Lake(params int[] numbers)
        {
            this.Stones = new List<int>(numbers);
        }
        public List<int> Stones
        {
            get { return this.stones; }
            private set { this.stones = value; }
        }


        public IEnumerator<int> GetEnumerator()
        {
            var evenNum = new List<int>();
            var oddNum = new List<int>();

            for (int i = 0; i < stones.Count; i++)
            {
                var element = stones[i];
                if (i % 2 == 0)
                {
                    evenNum.Add(element);
                }
                else
                {
                    oddNum.Add(element);
                }
            }
            oddNum.Reverse();
            evenNum.AddRange(oddNum);
            foreach (var item in evenNum)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
