using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideTheLabyrinth
{
    public class Point
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Point()
        {
            Y = 0;
            X = 0;
        }

        public Point(int y, int x)
        {
            Y = y;
            X = x;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Y == p2.Y && p1.X == p2.X;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return p1.Y != p2.Y | p1.X != p2.X;
        }
    }
}
