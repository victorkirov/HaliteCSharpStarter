using System;

namespace Halite
{
    public class Config
    {
        public int PlayerTag { get; private set; }
        public int MapWidth { get; private set; }
        public int MapHeight { get; private set; }

        public int StrengthToMoveToNeighbour => 25;
        
        public int Turn { get; private set; }

        private static Config _config;

        public static void Init(int playerTag, int mapWidth, int mapHeight)
        {
            _config = new Config
            {
                PlayerTag = playerTag,
                MapHeight = mapHeight,
                MapWidth = mapWidth,
                Turn = 0
            };
        }

        public static Config Get()
        {
            if (_config == null)
                throw new Exception("Config not initialised");

            return _config;
        }

        public static void IncrementTurn()
        {
            Get().Turn++;
        }
    }
}
