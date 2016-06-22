using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Homework.Point3D;


namespace Homework.Homework.Path3D
{
    public class Paths
    {
        private List<Points> arr = new List<Points>();

        public List<Points> Arr
        {
            get { return this.arr; }
            set { this.arr = value; }
        }

        public Paths(params Points[] arr)
        {
            foreach (var item in arr)
            {
                this.Arr.Add(item);
            }
        }

       
    }
}
