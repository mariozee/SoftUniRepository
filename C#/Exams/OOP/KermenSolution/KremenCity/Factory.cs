namespace KremenCity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;

    public class Factory
    {
        private const string Pattern = @"([A-Za-z]+)\(([0-9,.\s]+?)\)";

        public Household CreateHousehold(string input)
        {
            MatchCollection matches = Regex.Matches(input, Pattern);
            if (matches.Count == 0)
            {
                throw new ArgumentException();
            }

            string householdType = matches[0].Groups[1].Value;

            switch (householdType)
            {
                case "YoungCouple":
                    var youngCouple = CreateYoungCouple(matches);
                    return youngCouple;
                case "YoungCoupleWithChildren":
                    var youngCoupleWithChildren = CreateYoungCoupleWithChildren(matches);
                    return youngCoupleWithChildren;
                case "OldCouple":
                    var oldCouple = CreateOldCouple(matches);
                    return oldCouple;
                case "AloneYoung":
                    var singleYoung = CreateSingleYoung(matches);
                    return singleYoung;
                case "AloneOld":
                    var singleOld = CreateSingleOld(matches);
                    return singleOld;
                default:
                    throw new ArgumentException();
            }
        }

        private Household CreateSingleOld(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);
            Household household = new SingleOld(salary);

            return household;
        } 

        private Household CreateSingleYoung(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);

            Household household = new SingleYoung(salary, laptopCost);

            return household;
        }

        private Household CreateOldCouple(MatchCollection matches)
        {
            decimal[] salaries = GetCoupleSalaries(matches[0].Groups[2].Value);
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

            Household household = new OldCouple(salaries[0], salaries[1], tvCost, fridgeCost, stoveCost);

            return household;
        }

        private Household CreateYoungCoupleWithChildren(MatchCollection matches)
        {
            decimal[] salaries = GetCoupleSalaries(matches[0].Groups[2].Value);
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            var childs = new List<Child>();
            for (int i = 4; i < matches.Count; i++)
            {
                decimal childCost = matches[i]
                    .Groups[2]
                    .Value
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToList()
                    .Sum();

                var child = new Child(childCost);
                childs.Add(child);
            }

            Household household = new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, childs);

            return household;
        }

        private Household CreateYoungCouple(MatchCollection matches)
        {
            decimal[] salaries = GetCoupleSalaries(matches[0].Groups[2].Value);
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            Household household = new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);

            return household;
        }

        private decimal[] GetCoupleSalaries(string matchValue)
        {
            decimal[] salaries = matchValue
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            return salaries;
        }
    }
}