using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerProject
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stopwatch a = Stopwatch.StartNew();
            var crowler = new WebCrawler();

            for (int i = 1; i <= 7; i++)
            {
                crowler.AddPendingUrl("http://veloboost.bg/vilki?page=" + i);
            }

            crowler.Run("http://veloboost.bg/");
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
