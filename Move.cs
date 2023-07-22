using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideTheLabyrinth
{
    public class Move
    {
        public int[] Position { get; set; }
        public string Direction { get; set; }

        public Move() 
        {
            Position = new int[] { 0, 0 };
            Direction = "down";
        }

        public Move(int[] position, string direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
