using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeProject
{
    abstract class GameObject
    {
        int x, y;
        public GameObject(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int X { 
            get { return x; }
            set { x = value; } 
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public abstract void Draw(Graphics g);
    }
}
