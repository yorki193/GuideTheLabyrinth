using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideTheLabyrinth
{
    public class Move
    {
        public Point Position { get; set; }
        public DirectionType Direction { get; set; }

        public Move() 
        {
            Position = new Point(0, 0);
            Direction = DirectionType.down;
        }

        public Move(Point position, DirectionType direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
