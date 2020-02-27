using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControlTest
{
    [TestClass]
    public class RoomTest
    {
        public void ContainsInSquareTest()
        {
            var room = new Room(5, 5, new Point(0, 0));

            Assert.IsTrue(room.Contains(new Point(1, 1)));
            Assert.IsTrue(room.Contains(new Point(5, 5)));
            Assert.IsTrue(room.Contains(new Point(0, 0)));
            Assert.IsFalse(room.Contains(new Point(6, 6)));
            Assert.IsFalse(room.Contains(new Point(1, 6)));
            Assert.IsFalse(room.Contains(new Point(6, 1)));
            Assert.IsFalse(room.Contains(new Point(-6, 1)));
            Assert.IsFalse(room.Contains(new Point(-6, -1)));
        }

        public void ContainsInCircleTest()
        {
            var room = new Room(5, new Point(0, 0));

            Assert.IsTrue(room.Contains(new Point(1, 1)));
            Assert.IsTrue(room.Contains(new Point(-5, -5)));
            Assert.IsFalse(room.Contains(new Point(1, 6)));
            Assert.IsFalse(room.Contains(new Point(6, 1)));
            Assert.IsFalse(room.Contains(new Point(-6, 1)));
            Assert.IsFalse(room.Contains(new Point(-6, -1)));
        }
    }
}
