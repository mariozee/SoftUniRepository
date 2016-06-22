using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.BitArray
{
    class BitArray
    {
        private List<int> sequence = new List<int>();

        public BitArray(params int[] seq)
        {
            foreach (var item in seq)
            {
                this.Sequence.Add(item);
            }
        }

        public List<int> Sequence
        {
            get { return this.sequence; }
            set { this.sequence = value; }
        }

    }
}
