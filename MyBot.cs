using System;
using System.Linq;

namespace Halite
{
    public class MyBot
    {
        public const string MyBotName = "MyC#Bot";

        public static void Main(string[] args)
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
            
            var map = Networking.GetInit();

            Networking.SendInit(MyBotName); // Acknoweldge the init and begin the game

            var random = new Random();
            while (true)
            {
                Networking.GetFrame(map); // Update the map

                var moves = map.GetMySites().Select(site => new Move
                {
                    Site = site, Direction = (Direction) random.Next(5)
                }).ToList();

                Networking.SendMoves(moves); // Send moves
            }
        }
    }
}