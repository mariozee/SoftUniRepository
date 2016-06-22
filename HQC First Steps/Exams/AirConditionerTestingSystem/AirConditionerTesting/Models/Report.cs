using System;

namespace AirConditionerTesting.Models
{
    using System.Text;

    public class Report
    {
        public Report(string manufacturer, string model, int mark)
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
            var builder = new StringBuilder();
            string output = string.Empty;
            string result = string.Empty;

            if (this.Mark == 0)
            {
                result = "Failed";
            }
            else if (this.Mark == 1)
            {
                result = "Passed";
            }

            builder.AppendLine("Report").AppendLine("====================")
                .AppendFormat("Manufacturer: {0}", this.Manufacturer)
                .AppendLine().AppendFormat("Model: {0}", this.Model)
                .AppendLine().AppendFormat("Mark: {0}", result)
                .AppendLine().Append("====================");

            return builder.ToString();
        }
    }
}
