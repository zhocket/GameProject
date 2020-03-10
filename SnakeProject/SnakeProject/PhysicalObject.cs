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
        public PhysicalObject(int x, int y) : base(x, y)
        {

        }

        public bool CheckCollision(int xPos, int yPos, int xNext, int yNext)
        {
            return false;
        }

    }
}
