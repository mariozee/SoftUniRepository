using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoatRacingSimulator.Exceptions;
using BoatRacingSimulator.Controllers;
using BoatRacingSimulator.Models.Boats;
using BoatRacingSimulator.Models.Engines;
using BoatRacingSimulator.Models;

namespace BoatRacingSimulator.Test
{
    [TestClass]
    public class StartRaceTest
    {
        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void StartRace_NotSatRace_ShouldThrowExcpetion()
        {
            var controller = new BoatSimulatorController();
            controller.StartRace();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException))]
        public void StartRace_NotEnoghtContestants_ShouldThrowExcpetion()
        {
            var controller = new BoatSimulatorController();

            controller.CreateBoatEngine("Engine1", 50, 50, Enumerations.EngineType.Jet);
            controller.CreateYacht("Boat1", 400, "Engine1", 50);
            controller.CreateRowBoat("Boat2", 300, 2);

            controller.OpenRace(200, 30, 40, true);

            controller.SignUpBoat("Boat1");
            controller.SignUpBoat("Boat2");

            controller.StartRace();
        }

        [TestMethod]
        public void StartRace_ValidContestance_ShouldReturnMessageWithFirstThree()
        {
            var controller = new BoatSimulatorController();

            SetRace(controller);            

            string message = controller.StartRace();

            string expectedMessage = "First place: PowerBoat Model: Boat2 Time: 2.85 sec\r\n";
            expectedMessage += "Second place: RowBoat Model: Boat1 Time: 6.45 sec\r\n";
            expectedMessage += "Third place: SailBoat Model: Boat3 Time: Did not finish!";

            Assert.AreEqual(expectedMessage, message);
        }        

        [TestMethod]
        public void StartRace_FinishedRace_CurrentRaceMustBeNull()
        {
            var controller = new BoatSimulatorController();

            SetRace(controller);

            controller.StartRace();

            Assert.IsNull(controller.CurrentRace);
        }

        private void SetRace(BoatSimulatorController controller)
        {
            controller.CreateBoatEngine("Engine1", 250, 100, Enumerations.EngineType.Jet);
            controller.CreateBoatEngine("Engine2", 150, 150, Enumerations.EngineType.Sterndrive);
            controller.CreateRowBoat("Boat1", 450, 6);
            controller.CreatePowerBoat("Boat2", 2200, "Engine1", "Engine2");
            controller.CreateSailBoat("Boat3", 200, 98);

            controller.OpenRace(1000, 10, 5, true);

            controller.SignUpBoat("Boat1");
            controller.SignUpBoat("Boat2");
            controller.SignUpBoat("Boat3");
        }
    }
}
