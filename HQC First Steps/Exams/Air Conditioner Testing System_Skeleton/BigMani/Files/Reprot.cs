using System;

namespace BigMani.Files
{
    using System.Text;

    public class Reprot
    {
        public Reprot(string manufacturer, string model, int mark)
        {
            Manufacturer = manufacturer;
            Model = model;
            Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Mark { get; set; }

        public override string ToString()
        {
            string result = string.Format("Report {0}{1}{0}Manufactorer: {2}{0}Model: {3}{0}Mark: {4}{0}{1}",
                Environment.NewLine, new string('=', 20), this.Manufacturer, this.Model, 
                this.Mark == 0 ? "Failed" : "Passed");
                    
            return result;
        }
    }
}
