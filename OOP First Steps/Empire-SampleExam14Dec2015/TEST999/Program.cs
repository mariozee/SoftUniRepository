using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST999
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            dic.Add("asd", 0);

            dic[0] += "a";

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
