using RobotControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControl
{
    /// <summary>
    /// Class for describing the one position in 2D space
    /// </summary>
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var location = obj as Point;
            return location != null &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
