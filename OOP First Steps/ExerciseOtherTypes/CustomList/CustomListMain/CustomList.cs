using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListMain
{
    public class CustomList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;
        private int currentIndex;

        public CustomList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;

        }

        public int Count
        {
            get { return this.currentIndex; }
        }

        public void Add(T element)
        {
            if (this.currentIndex == this.elements.Length)
            {
                Resize();
            }
            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        [Version(1.1)]
        public void RemoveAt(int index)
        {
            if (index > this.elements.Length - 1)
            {
                throw new InvalidOperationException("There is nothing on that index");
            }

            for (int i = index; i < this.elements.Length - 1; i++)
            {
                this.elements[i] = elements[i + 1];
            }
            this.currentIndex--;
        }

        public void Remove(T value)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(value) == 0)
                {
                    for (int j = i; j < this.elements.Length - 1; j++)
                    {
                        this.elements[j] = this.elements[j + 1];
                    }
                    this.currentIndex--;
                }
            }
        }

        [Version(1.1)]
        public void RemoveAll(T value)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(value) == 0)
                {
                    for (int j = i; j < this.elements.Length - 1; j++)
                    {
                        this.elements[j] = this.elements[j + 1];
                    }
                    i--;
                    this.currentIndex--;
                }
            }
        }

        [Version(1.1)]
        public void PrintValueAt(int index)
        {
            T value = this.elements[index];
            Console.WriteLine(value);
        }

        public int GetLenght()
        {
            return this.currentIndex;
        }

        private void Resize()
        {
            T[] newList = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newList[i] = this.elements[i];
            }
            this.elements = newList;
        }

    }
}
