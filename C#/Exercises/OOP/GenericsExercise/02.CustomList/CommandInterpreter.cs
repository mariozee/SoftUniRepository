using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomList
{
    public class CommandInterpreter
    {
        private Sorter sorter;

        public CommandInterpreter()
        {
            this.sorter = new Sorter();
        }

        public string Dispatch<T>(string[] args, CustomList<T> list) where T : IComparable<T>
        {
            string output = string.Empty;

            T element = default(T);
            int index = 0;

            string command = args[0];
            switch (command)
            {
                case "Add":
                    element = (T)Convert.ChangeType(args[1], typeof(T));                
                    list.Add(element);
                    break;
                case "Remove":
                    index = int.Parse(args[1]);
                    output = list.Remove(index).ToString();
                    break;
                case "Contains":
                    element = (T)Convert.ChangeType(args[1], typeof(T));
                    output = list.Contains(element).ToString().ToLower();
                    break;
                case "Swap":
                    int x = int.Parse(args[1]);
                    int y = int.Parse(args[2]);
                    list.Swap(x, y);
                    break;
                case "Greater":
                    element = (T)Convert.ChangeType(args[1], typeof(T));
                    output = list.CountGreatherThen(element).ToString();
                    break;
                case "Max":
                    output = list.Max().ToString();
                    break;
                case "Min":
                    output = list.Min().ToString();
                    break;
                case "Print":
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in list)
                    {
                        sb.AppendLine(item.ToString());
                    }
  
                    output = sb.ToString().Trim();
                    break;
                case "Sort":
                    sorter.Sort(list);
                    break;
                case "END":
                    Startup.Stop();
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
