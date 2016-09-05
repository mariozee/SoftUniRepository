namespace LambdaCore_Skeleton.Collection
{
    using System;
    using System.Collections.Generic;

    public class LStack<T>
    {
        private LinkedList<T> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<T>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public void Push(T item)
        {
            this.innerList.AddLast(item);
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException(GlobalMessages.FailedDettachFragment);
            }

            T fragment = this.innerList.Last.Value;
            this.innerList.RemoveLast();

            return fragment;
        }

        //public T Peek()
        //{
        //    T peekedItem = this.innerList.First();
        //    return peekedItem;
        //}

        public Boolean IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
