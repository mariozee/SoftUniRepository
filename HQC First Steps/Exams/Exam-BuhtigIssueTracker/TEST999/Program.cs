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
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Title")
                .AppendLine("Priority: *")
                .AppendLine("Issue discription")
                .Append("Tags: tag1,tag2");

            Console.WriteLine(expectedOutput);
        }
    }
}
