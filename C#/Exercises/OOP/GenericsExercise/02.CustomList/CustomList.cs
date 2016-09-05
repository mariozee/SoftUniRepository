namespace _02.CustomList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 8;

        private int currentIndex = 0;

        private T[] array;

        public CustomList()
        {
            this.array = new T[DefaultSize];
        }

        public int Count { get { return this.currentIndex; } }

        public int Capacity { get { return this.array.Length; } }

        public T this[int index]
        {
            get { return array[index]; }
            set
            {
                if (index >= currentIndex)
                {
                    throw new IndexOutOfRangeException();
                }

                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.currentIndex == this.array.Length - 1)
            {
                this.BoostSize();
            }

            this.array[this.currentIndex] = element;
            this.currentIndex++;
        }

        public T Remove(int index)
        {
            if (index >= this.currentIndex)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.currentIndex < this.array.Length / 2 && this.array.Length / 2 >= DefaultSize)
            {
                DropSize();
            }

            T removedValue = this.array[index];

            Rearange(index);

            this.array[currentIndex - 1] = default(T);
            this.currentIndex--;

            return removedValue;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.array[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int i, int j)
        {
            if (i > this.currentIndex || j > this.currentIndex)
            {
                throw new IndexOutOfRangeException();
            }

            var temp = this.array[i];
            this.array[i] = this.array[j];
            this.array[j] = temp;
        }

        public int CountGreatherThen(T element)
        {
            int count = 0;

            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.array[i].CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException();
            }

            T maxValue = this.array[0];
            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.array[i].CompareTo(maxValue) == 1)
                {
                    maxValue = this.array[i];
                }
            }

            return maxValue;
        }

        public T Min()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException();
            }

            T minValue = this.array[0];
            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.array[i].CompareTo(minValue) == -1)
                {
                    minValue = this.array[i];
                }
            }

            return minValue;
        }

        private void Rearange(int index)
        {
            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void DropSize()
        {
            while (this.currentIndex < this.array.Length / 2)
            {
                Array.Resize(ref this.array, this.array.Length / 2);
            }
        }

        private void BoostSize()
        {
                Array.Resize(ref this.array, this.array.Length * 2);            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
