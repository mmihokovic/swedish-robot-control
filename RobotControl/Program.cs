using RobotControl.Interfaces;
using System;
using System.Collections.Generic;

namespace RobotControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var language = GetLanguage();

            Console.Write(language == Language.English ? "Room type? ([S]quare/[C]ircular): " : "Rumstyp? ([K]vadrat / [C]irkulär): ");
            var roomTypeResponse = Console.ReadLine();

            IRoom room = null;
            if(String.IsNullOrWhiteSpace(roomTypeResponse) || (roomTypeResponse.ToString()[0] == 'S' || roomTypeResponse.ToString()[0] == 'K'))
            {
                room = GetSquareRoomData(language); // Default in none selected
            }
            else if (!String.IsNullOrWhiteSpace(roomTypeResponse) && roomTypeResponse.ToString()[0] == 'C')
            {
                room = GetCircularRoomData(language);
            }

            Console.Write(language == Language.English ? "Enter robot instructions: " : "Ange robotinstruktioner: ");
            var robotInstruction = Console.ReadLine();

            var robot = new RobotControl(room, language);
            robot.ExecuteInstructions(robotInstruction);
            
            Console.WriteLine("Robot position:" + robot.GetFormatedCurrentPosition());
            Console.WriteLine(language == Language.English ? "Press any key to continue..." : "Tryck på valfri tangent för att fortsätta...");
            Console.Read();
        }

        private static Language GetLanguage()
        {
            var language = Language.English;
            Console.Write("Language ([S]venska/[E]nglish): ");
            string languageResponse = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(languageResponse) && languageResponse.ToUpperInvariant()[0] == 'S')
            {
                language = Language.Swedish;
            }

            return language;
        }

        private static IRoom GetSquareRoomData(Language language)
        {
            Console.Write(language == Language.English ? "Room width: " : "Rumsbredd: ");
            var width = int.Parse(Console.ReadLine());
            Console.Write(language == Language.English ? "Room length: " : "Rumslängd: ");
            var length = int.Parse(Console.ReadLine());            

            return new Room(length, width, GetStartingPoint(language));
        }

        private static IRoom GetCircularRoomData(Language language)
        {
            Console.Write(language == Language.English ? "Room radius: " : "Rumsradie: ");
            var radius = int.Parse(Console.ReadLine());

            return new Room(radius, GetStartingPoint(language));
        }

        private static IPoint GetStartingPoint(Language language)
        {
            Console.Write(language == Language.English ? "Start point x: " : "Startpunkt x: ");
            var startPointX = int.Parse(Console.ReadLine());
            Console.Write(language == Language.English ? "Start point y: " : "Startpunkt y: ");
            var startPointY = int.Parse(Console.ReadLine());

            return new Point(startPointX, startPointY);
        }
    }
}
