using RobotControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl
{
    /// <summary>
    /// Class for describing a 2D room where robot is located. It can have two shapes, square or circular
    /// </summary>
    public class Room : IRoom
    {
        /// <summary>
        /// Robot start position
        /// </summary>
        public IPoint StartPosition { get; set; }

        private int? lenght;
        private int? width;
        private int? radius;

        /// <summary>
        /// Define a square room.
        /// </summary>
        /// <param name="lenght">Room length</param>
        /// <param name="width">Room width</param>
        /// <param name="startPosition">Robot start position</param>
        public Room(int lenght, int width, IPoint startPosition)
        {
            this.lenght = lenght;
            this.width = width;
            StartPosition = startPosition;
        }

        /// <summary>
        /// Define a circular room.
        /// </summary>
        /// <param name="radius">Room radius</param>
        /// <param name="startPosition">Robot start position</param>
        public Room(int radius, IPoint startPosition)
        {
            this.radius = radius;
            StartPosition = startPosition;
        }

        /// <summary>
        /// Method for checking if poini is in the room. Works for square and circular type od room
        /// </summary>
        /// <param name="position">Position for checking if is in room or not</param>
        /// <returns>True if position is in room, false otherwise</returns>
        public bool Contains(IPoint position)
        {
            if(lenght.HasValue && width.HasValue)
            {
                return position.X >= 0 && position.X <= width &&
                    position.Y >= 0 && position.Y <= lenght;
            }
            else if (radius.HasValue)
            {
                return Math.Abs(position.X) <= radius && Math.Abs(position.Y) <= radius;
            }
            return false;
        }
    }
}
