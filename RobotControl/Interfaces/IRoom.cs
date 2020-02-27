using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Interfaces
{
    /// <summary>
    /// Interface for defininig a room
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// Robot start position
        /// </summary>
        IPoint StartPosition { get; }

        /// <summary>
        /// Method for checking if poini is in the room. Works for square and circular type od room
        /// </summary>
        /// <param name="position">Position for checking if is in room or not</param>
        /// <returns>True if position is in room, false otherwise</returns>
        bool Contains(IPoint position);
    }
}
