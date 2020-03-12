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
        public PhysicalObject(int x, int y) : base(x, y) { }

        public bool CheckCollision(int xOther, int yOther)
        {
            if (new Rectangle(X, Y, 1, 1).IntersectsWith(new Rectangle(xOther, yOther, 1, 1)) == true)
            {
                return true;
            }
            else
                return false;
        }

    }
}
