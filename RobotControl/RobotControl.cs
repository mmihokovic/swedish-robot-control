using RobotControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotControl
{
    /// <summary>
    /// A class for defining the robot control
    /// </summary>
    public class RobotControl : IRobotControl
    {
        private IPoint currentPosition;
        private CardinalDirection direction;
        private IRoom room;
        private Language language;

        public RobotControl(IRoom room, Language language)
        {
            this.room = room;
            currentPosition = new Point(this.room.StartPosition.X, this.room.StartPosition.Y);
            direction = CardinalDirection.North;
            this.language = language;
        }

        /// <summary>
        /// Execute a set of instructions for rotating right, left or moving forward
        /// </summary>
        /// <param name="instructions">Set of instructions, one letter per command, English or Swedish</param>
        public void ExecuteInstructions(string instructions)
        {
            var instructionsForExecution = ParseInstructions(instructions);

            foreach(var i in instructionsForExecution)
            {
                switch (i)
                {
                    case RobotInstruction.TurnLeft:
                        TurnLeft();
                        break;
                    case RobotInstruction.TurnRight:
                        TurnRight();
                        break;
                    case RobotInstruction.MoveForward:
                        MoveForward();
                        break;
                }
            }
        }

        private IEnumerable<RobotInstruction> ParseInstructions(string instructions)
        {
            var instructionsList = new List<RobotInstruction>();

            foreach(var c in instructions)
            {
                switch (c)
                {
                    case 'L': //fallthrough Left/Vänster
                    case 'V':
                        instructionsList.Add(RobotInstruction.TurnLeft);
                        break;
                    case 'R': //fallthrough Right/Höger
                    case 'H':
                        instructionsList.Add(RobotInstruction.TurnRight);
                        break;
                    case 'F': //fallthrough Move forward/Gå framåt
                    case 'G':
                        instructionsList.Add(RobotInstruction.MoveForward);
                        break;
                }
            }

            return instructionsList;
        }

        /// <summary>
        /// Gets robot cardinal direction
        /// </summary>
        /// <returns>Robot cardinal direction</returns>
        public CardinalDirection GetCardinalDirection()
        {
            return direction;
        }

        /// <summary>
        /// Gets current robot position in coordinates
        /// </summary>
        /// <returns>Point where robot is currently positioned</returns>
        public IPoint GetCurrentPosition()
        {
            return currentPosition;
        }

        /// <summary>
        /// Gets robot position and direction ready for print
        /// </summary>
        /// <returns>Formated robot position and direction</returns>
        public string GetFormatedCurrentPosition()
        {
            return GetCurrentPosition().X + " " + GetCurrentPosition().Y + " " + FormatCardinalDirection();
        }

        private string FormatCardinalDirection()
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    return language == Language.English ? "N" : "N";
                case CardinalDirection.East:
                    return language == Language.English ? "E" : "Ö";
                case CardinalDirection.West:
                    return language == Language.English ? "W" : "V";
                case CardinalDirection.South:
                    return language == Language.English ? "S" : "S";
            }
            return String.Empty;
        }

        /// <summary>
        /// Move robot forward in currently faced position
        /// </summary>
        public void MoveForward()
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    currentPosition = MoveRobotToNewPosition(new Point(currentPosition.X, currentPosition.Y - 1));
                    break;
                case CardinalDirection.East:
                    currentPosition = MoveRobotToNewPosition(new Point(currentPosition.X + 1, currentPosition.Y));
                    break;
                case CardinalDirection.West:
                    currentPosition = MoveRobotToNewPosition(new Point(currentPosition.X - 1, currentPosition.Y));
                    break;
                case CardinalDirection.South:
                    currentPosition = MoveRobotToNewPosition(new Point(currentPosition.X, currentPosition.Y + 1));
                    break;
            }
        }

        private IPoint MoveRobotToNewPosition(IPoint newPosition)
        {
            return room.Contains(newPosition) ? newPosition : currentPosition;
        }

        /// <summary>
        /// Turn robot to left from current position
        /// </summary>
        public void TurnLeft()
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    direction = CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    direction = CardinalDirection.North;
                    break;
                case CardinalDirection.West:
                    direction = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    direction = CardinalDirection.East;
                    break;
            }
        }

        /// <summary>
        /// Turn robot to right from current position
        /// </summary>
        public void TurnRight()
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    direction = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    direction = CardinalDirection.South;
                    break;
                case CardinalDirection.West:
                    direction = CardinalDirection.North;
                    break;
                case CardinalDirection.South:
                    direction = CardinalDirection.West;
                    break;
            }
        }
    }
}
