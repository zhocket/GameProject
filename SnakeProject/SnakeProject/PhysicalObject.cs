using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    abstract class PhysicalObject : GameObject
    {
        //int x, y;
        public PhysicalObject(int _x, int _y):base(_x, _y)
        {
            //x = _x;
            //y = _y;
        }



        public bool collision(int x, int y, int direction)
        {
            return false;
        }
    }
}
