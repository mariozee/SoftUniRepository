using System.Collections.Generic;
using System;
using System.Linq;
using AirConditionerTesting.Exceptions;
using AirConditionerTesting.Models;
using AirConditionerTesting.Interfaces;
using AirConditionerTesting.Core;

namespace AirConditionerTesting.Core
{
    public static class AirConditionsData
    {
        static AirConditionsData()
        {
            AirConditioners = new List<IAirConditioner>();
            Reports = new List<Report>();
        }

        public static List<IAirConditioner> AirConditioners { get; set; }

        public static List<Report> Reports { get; set; }

        public static void AddAirConditioner(IAirConditioner airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        public static void RemoveAirConditioner(IAirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        public static IAirConditioner GetAirConditioner(string manufacturer, string model)
        {
            try
            {
                return AirConditioners.Where(x => x.Manufacturer == manufacturer && x.Model == model).First();
            }
            catch (Exception)
            {
                throw new InvalidOperationException(GlobalMessages.NONEXIST);
            }
        }

        public static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Report report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Report report)
        {
            Reports.Remove(report);
        }

        public static Report GetReport(string manufacturer, string model)
        {
            try
            {
                return Reports.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new NonExistantEntryException(GlobalMessages.NONEXIST);
            }
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
