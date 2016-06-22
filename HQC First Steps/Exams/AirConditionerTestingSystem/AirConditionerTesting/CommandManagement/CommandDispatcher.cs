namespace AirConditionerTesting.CommandManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Exceptions;
    using Models;

    public class CommandDispatcher
    {
        private Engine engine;

        public CommandDispatcher(Engine engine)
        {
            this.engine = engine;
        }

        public string DispatchCommand()
        {
            var commands = this.engine.command;
            try
            {
                switch (commands.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.engine.ValidateParametersCount(commands, 4);
                        return this.RegisterStationaryAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            commands.Parameters[2],
                            int.Parse(commands.Parameters[3]));
                    case "RegisterCarAirConditioner":
                        this.engine.ValidateParametersCount(commands, 3);
                        return this.RegisterCarAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            int.Parse(commands.Parameters[2]));
                    case "RegisterPlaneAirConditioner":
                        this.engine.ValidateParametersCount(commands, 4);
                        return this.RegisterPlaneAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1],
                            int.Parse(commands.Parameters[2]),
                            commands.Parameters[3]);
                    case "TestAirConditioner":
                        this.engine.ValidateParametersCount(commands, 2);
                        return this.TestAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1]);
                    case "FindAirConditioner":
                        this.engine.ValidateParametersCount(commands, 2);
                        return this.FindAirConditioner(
                            commands.Parameters[0],
                            commands.Parameters[1]);
                    case "FindReport":
                        this.engine.ValidateParametersCount(commands, 2);
                        return this.FindReport(
                            commands.Parameters[0],
                            commands.Parameters[1]);
                    case "FindAllReportsByManufacturer":
                        this.engine.ValidateParametersCount(commands, 1);
                        return this.FindAllReportsByManufacturer(commands.Parameters[0]);
                    case "Status":
                        this.engine.ValidateParametersCount(commands, 0);
                        return this.engine.Status();
                    default:
                        throw new IndexOutOfRangeException(GlobalMessages.INVALIDCOMMAND);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(GlobalMessages.INVALIDCOMMAND, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(GlobalMessages.INVALIDCOMMAND, ex.InnerException);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            if (AirConditionsData.AirConditioners.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                throw new InvalidOperationException(GlobalMessages.DUPLICATE);
            }

            var airConditioner = new StationaryAirConditioners(manufacturer, model, energyEfficiencyRating, powerUsage);
            AirConditionsData.AirConditioners.Add(airConditioner);
            string message = string.Format("Air Conditioner model {0} from {1} registered successfully.", model, manufacturer);

            return message;            
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            if (AirConditionsData.AirConditioners.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                throw new InvalidOperationException(GlobalMessages.DUPLICATE);
            }

            var airConditioner = new CarAirConditioners(manufacturer, model, volumeCoverage);
            AirConditionsData.AirConditioners.Add(airConditioner);
            string message = string.Format("Air Conditioner model {0} from {1} registered successfully.",
                model, manufacturer);

            return message;
        }

        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            if (AirConditionsData.AirConditioners.
                Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                throw new InvalidOperationException(GlobalMessages.DUPLICATE);
            }

            var airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            AirConditionsData.AirConditioners.Add(airConditioner);
            string message = string.Format("Air Conditioner model {0} from {1} registered successfully.",
                model, manufacturer);

            return message;
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            if (AirConditionsData.Reports.
                Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                throw new InvalidOperationException(GlobalMessages.DUPLICATE);
            }

            var airConditioner = AirConditionsData.GetAirConditioner(manufacturer, model);

            var mark = airConditioner.Test();
            AirConditionsData.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            throw new InvalidOperationException(string.Format(GlobalMessages.TEST, model, manufacturer));
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            var airConditioner = AirConditionsData.GetAirConditioner(manufacturer, model);
            throw new InvalidOperationException(airConditioner.ToString());
        }

        public string FindReport(string manufacturer, string model)
        {
            Report report = AirConditionsData.GetReport(manufacturer, model);
            try
            {
                return report.ToString();
            }
            catch (Exception)
            {
                throw new NonExistantEntryException(GlobalMessages.NONEXIST);
            }

            //throw new InvalidOperationException(report.ToString());
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = AirConditionsData.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return GlobalMessages.NOREPORTS;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
    }
}
