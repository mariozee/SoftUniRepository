using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class ElementBuilder
    {
        //private string tag;
        private List<string[]> atributes = new List<string[]>();
        private string content;

        public ElementBuilder(string tag)
        {
            this.Tag = tag;
        }

        public string Tag { get; set; }

        public static string operator*(ElementBuilder element, int num)
        {
            string output = string.Empty;
            string htmlElement = element.ToString();

            for (int i = 0; i < num; i++)
            {
                output += htmlElement;               
            }
            return output;
        }

        public void AddAtribute(string att, string val)
        {
            string[] temp = new string[2];
            temp[0] = att;
            temp[1] = val;
            this.atributes.Add(temp);
        }

        public void AddContent(string con)
        {
            this.content = con; 
        }

        public override string ToString()
        {
            string output = "<" + this.Tag;
            foreach (string[] atribute in atributes)
            {
                output += string.Format(" {0}=\"{1}\"", atribute[0], atribute[1]);
            }
            output += ">";
            output += string.Format("{0}</{1}>{2}", this.content, this.Tag, Environment.NewLine);

            return output;
        }
    }
}
