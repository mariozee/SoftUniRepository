using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBox
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public T Element
        {
            get { return this.element; }
        }

        public override string ToString()
        {
            string output = $"{this.Element.GetType().FullName}: {this.Element}";
            return output;
        }
    }
}
