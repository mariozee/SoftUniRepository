using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoatRacingSimulator.Models;
using BoatRacingSimulator.Controllers;
using BoatRacingSimulator.Exceptions;

namespace BoatRacingSimulator.Test
{
    [TestClass]
    public class OpenRaceTest
    {
        [TestMethod]
        public void OpenRace_ValidRace_ShouldReturnSuccessMessage()
        {
            int dist = 100;
            int windSpeed = 5;
            int oceanSpeed = 10;
            bool allowMotrBoats = true;

            var controller = new BoatSimulatorController();

            string message = controller.OpenRace(dist, windSpeed, oceanSpeed, allowMotrBoats);
            string expectedMessage = string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    dist, windSpeed, oceanSpeed);

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void OpenRace_ExistingRace_ShouldThrowException()
        {
            int dist = 100;
            int windSpeed = 5;
            int oceanSpeed = 10;
            bool allowMotrBoats = true;

            var controller = new BoatSimulatorController();
            controller.OpenRace(dist, windSpeed, oceanSpeed, allowMotrBoats);
            controller.OpenRace(dist, windSpeed, oceanSpeed, allowMotrBoats);
        }

    }
}
