using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomList
{
    public class Sorter
    {
        public void Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            T temp;
            bool swaped = false;

            do
            {
                swaped = false;           

                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) == 1)
                    {
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;

                        swaped = true;
                    }
                }
            } while (swaped);
            
        }

    }
}
