using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotControl;
using RobotControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControlTest
{
    [TestClass]
    public class RobotControlTest
    {
        [TestMethod]
        public void TurnRightTest()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(0, 0)), Language.English);

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual(CardinalDirection.East, robotControl.GetCardinalDirection());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual(CardinalDirection.South, robotControl.GetCardinalDirection());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual(CardinalDirection.West, robotControl.GetCardinalDirection());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual(CardinalDirection.North, robotControl.GetCardinalDirection());

        }

        [TestMethod]
        public void TurnLeftTest()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(0, 0)), Language.English);

            robotControl.ExecuteInstructions("L");
            Assert.AreEqual(CardinalDirection.West, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(0, 0), robotControl.GetCurrentPosition());

            robotControl.ExecuteInstructions("L");
            Assert.AreEqual(CardinalDirection.South, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(0, 0), robotControl.GetCurrentPosition());

            robotControl.ExecuteInstructions("L");
            Assert.AreEqual(CardinalDirection.East, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(0, 0), robotControl.GetCurrentPosition());

            robotControl.ExecuteInstructions("L");
            Assert.AreEqual(CardinalDirection.North, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(0, 0), robotControl.GetCurrentPosition());
        }

        [TestMethod]
        public void MoveForwardTest()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(1, 1)), Language.English);

            robotControl.ExecuteInstructions("F");
            Assert.AreEqual(CardinalDirection.North, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(1, 0), robotControl.GetCurrentPosition());            
        }

        [TestMethod]
        public void ExecuteInstructionsTest()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(1, 2)), Language.English);

            robotControl.ExecuteInstructions("RFRFFRFRF");
            Assert.AreEqual(CardinalDirection.North, robotControl.GetCardinalDirection());
            Assert.AreEqual(new Point(1, 3), robotControl.GetCurrentPosition());
        }

        [TestMethod]
        public void PrintCurrentPositionEnglish()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(1, 2)), Language.English);

            Assert.AreEqual("1 2 N", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 E", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 S", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 W", robotControl.GetFormatedCurrentPosition());
        }

        [TestMethod]
        public void PrintCurrentPositionSwedish()
        {
            var robotControl = new RobotControl.RobotControl(new Room(5, 5, new Point(1, 2)), Language.Swedish);

            Assert.AreEqual("1 2 N", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 Ö", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 S", robotControl.GetFormatedCurrentPosition());

            robotControl.ExecuteInstructions("R");
            Assert.AreEqual("1 2 V", robotControl.GetFormatedCurrentPosition());
        }
    }
}
