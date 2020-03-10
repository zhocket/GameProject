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
        private int x, y;
        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public abstract void Draw(Graphics g);
    }
}
