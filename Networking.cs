using System;
using System.Collections.Generic;

namespace Halite
{
    /// <summary>
    /// Used for communication with server
    /// </summary>
    public static class Networking
    {
        /// <summary>
        /// Call once at the start of a game to load the map and player tag from the first four stdin lines.
        /// </summary>
        public static Map GetInit()
        {
            int playerTag;

            var tag = ReadNextLine();
            var mapSize = ReadNextLine();
            var productionMap = ReadNextLine();
            var gameMap = ReadNextLine();

            // Line 1: Player tag
            if (!int.TryParse(tag, out playerTag))
                throw new ApplicationException("Could not get player tag from stdin during init");

            // Lines 2-4: Map
            var map = Map.ParseMap(mapSize, productionMap, gameMap, playerTag);
            return map;
        }

        /// <summary>
        /// Call every frame to update the map to the next one provided by the environment.
        /// </summary>
        public static void GetFrame(Map map)
        {
            map.Update(ReadNextLine());
            Config.IncrementTurn();
        }


        /// <summary>
        /// Call to acknowledge the initail game map and start the game.
        /// </summary>
        public static void SendInit(string botName)
        {
            SendString(botName);
        }

        /// <summary>
        /// Call to send your move orders and complete your turn.
        /// </summary>
        public static void SendMoves(IEnumerable<Move> moves)
        {
            SendString(Move.MovesToString(moves));
        }

        private static string ReadNextLine()
        {
            var str = Console.ReadLine();
            if (str == null) throw new ApplicationException("Could not read next line from stdin");
            return str;
        }

        private static void SendString(string str)
        {
            Console.WriteLine(str);
        }
    }
}
