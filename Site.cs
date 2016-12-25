using System;
using System.Collections.Generic;
using System.Linq;

namespace Halite
{
    public enum Direction
    {
        Still = 0,
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }

    public class Site
    {
        public ushort Owner { get; internal set; }
        public ushort Strength { get; internal set; }
        public ushort Production { get; internal set; }

        public int X { get; }
        public int Y { get; }

        public Site Top { get; set; }
        public Site Bottom { get; set; }
        public Site Left { get; set; }
        public Site Right { get; set; }
        
        public Site(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Direction GetDirectionToNeighbour(Site neighbour)
        {
            if (neighbour == Top)
                return Direction.North;
            if (neighbour == Bottom)
                return Direction.South;
            if (neighbour == Left)
                return Direction.West;
            if (neighbour == Right)
                return Direction.East;

            throw new ArgumentException("Specified site is not a neighbour");
        }

        public bool IsMine()
        {
            return Owner == Config.Get().PlayerTag;
        }

        public bool IsEnemy()
        {
            return Owner != Config.Get().PlayerTag && Owner != 0;
        }

        public bool IsEmpty()
        {
            return Owner == 0;
        }

        public void PopulateNeighbours(Site top, Site bottom, Site left, Site right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
    }

    public class Move
    {
        public Site Site;
        public Direction Direction;

        public static string MovesToString(IEnumerable<Move> moves)
        {
            return string.Join(" ",
                moves.Select(m => $"{m.Site.X} {m.Site.Y} {(int)m.Direction}"));
        }
    }
}
