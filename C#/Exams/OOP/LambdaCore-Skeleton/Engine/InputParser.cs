using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Engine
{
    public class InputParser
    {
        public InputParser(string input)
        {
            Parse(input);
        }

        public string CommandName { get; private set; }

        public string[] Parameters { get; private set; }

        private void Parse(string input)
        {
            this.CommandName = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (input.Contains("@"))
            {
                int index = input.IndexOf('@');
                input = input.Substring(index);
                this.Parameters = input.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
