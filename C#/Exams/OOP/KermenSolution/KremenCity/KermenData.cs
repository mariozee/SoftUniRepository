namespace KremenCity
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class KermenData
    {
        private List<Household> data;

        public KermenData()
        {
            data = new List<Household>();
        }

        public void AddHousehold(Household household)
        {
            this.data.Add(household);
        }              

        public int GetPopulationCount()
        {
            int result = this.data.Sum(h => h.PeopleCount);

            return result;
        }

        public decimal GetTotalConsumption()
        {
            decimal result = this.data.Sum(h => h.Consumption);

            return result;
        }

        public void PaySalaries()
        {
            foreach (var household in this.data)
            {
                household.CollectIncome();
            }
        }

        public void PayBills()
        {
            RemoveInsolventHousehold();

            foreach (var household in this.data)
            {
                household.PayBill();
            }
        }

        private void RemoveInsolventHousehold()
        {
            data.RemoveAll(h => !h.CanPayBill());
        }
    }
}
