using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl.Interfaces
{
    /// <summary>
    /// Interface for defining robot control
    /// </summary>
    public interface IRobotControl
    {
        /// <summary>
        /// Turn robot to right from current position
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Turn robot to left from current position
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Move robot forward in currently faced position
        /// </summary>
        void MoveForward();

        /// <summary>
        /// Execute a set of instructions for rotating right, left or moving forward
        /// </summary>
        /// <param name="instructions">Set of instructions, one letter per command, English or Swedish</param>
        void ExecuteInstructions(string instructions);

        /// <summary>
        /// Gets current robot position in coordinates
        /// </summary>
        /// <returns>Point where robot is currently positioned</returns>
        IPoint GetCurrentPosition();

        /// <summary>
        /// Gets robot cardinal direction
        /// </summary>
        /// <returns>Robot cardinal direction</returns>
        CardinalDirection GetCardinalDirection();

        /// <summary>
        /// Gets robot position and direction ready for print
        /// </summary>
        /// <returns>Formated robot position and direction</returns>
        string GetFormatedCurrentPosition();
    }
}
