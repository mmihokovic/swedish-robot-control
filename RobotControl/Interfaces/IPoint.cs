using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Interfaces
{
    /// <summary>
    /// Interface of a single point in 2D space
    /// </summary>
    public interface IPoint
    {
        int X { get; }
        int Y { get; }

    }
}
