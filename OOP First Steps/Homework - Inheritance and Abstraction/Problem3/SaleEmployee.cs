namespace Problem3
{
    using Problem3.Enum;
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;
    using System;

    class SaleEmployee : Employee
    {
        public SaleEmployee(string firstName, string lastName, string id
                            , decimal salary, Department department, List<Sale> sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales { get; set; }

        //public void AddSale(Sale s)
        //{
        //    this.Sales.Add(s);
        //}

        //public void PrintSales()
        //{
        //    foreach (var item in Sales)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        public override string ToString()
        {
            string output = "";

            output += base.ToString();

            foreach (var sale in this.Sales)
            {
                output += sale;
            }

            return output;
        }
    }
}
