using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //IOManager.TraverseFolder(@"D:\Music");
            Data.InitializeData();
            Data.GetStudenScoresFromCourse("Unity", "Ivan");
        }        
    }
}
