using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeProject
{
    abstract class PhysicalObject : GameObject
    {
        private int xPos;
        private int yPos;
        public PhysicalObject(int x, int y) : base(x, y)
        {
            xPos = x;
            yPos = y;
        }

        public bool CheckCollision(int xNext, int yNext)
        {
            return false;
        }

    }
}
