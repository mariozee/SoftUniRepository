using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Homework.Path3D;

namespace Homework.Homework.Storage
{
    public class Stor
    {
        public static void SaveFile(string path, Paths arr)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Zisov4eto\Desktop\" + path + ".txt", true))
                foreach (var item in arr.Arr)
                {
                    writer.Write(item);
                }
        }

        public static void ReadFile(string str)
        {
            string line;
          
            try
            {
                StreamReader sr = new StreamReader(str);
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
                Console.WriteLine();
            }
            catch (FileNotFoundException fnfx)
            {
                Console.WriteLine(fnfx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
            finally
            {
                Console.WriteLine("Finaly!");
            }
        }       
    }
}
