using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class DispatchesrMain
    {
        static void Main()
        {
            ElementBuilder a = new ElementBuilder("div");
            a.AddAtribute("id", "page");
            a.AddAtribute("class", "big");
            a.AddContent("<p>Hello</p>");

            Console.WriteLine(a);
          //  Console.WriteLine(Dispatcher.CreateURL("https://abv.bg", "ABV", "mail serice"));
        }
    }
}
