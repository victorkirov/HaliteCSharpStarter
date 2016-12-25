using System;
using System.Collections.Generic;

namespace Halite
{
    public class RandomBot
    {
        public const string RandomBotName = "RandomC#Bot";

        public static void Main(string[] args)
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);

            var map = Networking.GetInit();

            Networking.SendInit(RandomBotName);

            var random = new Random();
            while (true)
            {
                Networking.GetFrame(map);

                var moves = new List<Move>();

                foreach (var site in map.GetMySites())
                {
                    moves.Add(new Move
                    {
                        Site = site,
                        Direction = (Direction)random.Next(5)
                    });
                }

                Networking.SendMoves(moves); // Send moves
            }
        }
    }
}
