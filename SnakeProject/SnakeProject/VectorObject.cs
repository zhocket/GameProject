using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeProject
{
    abstract class VectorObject : PhysicalObject
    {
        public enum direction { up, down, left, right};
        private direction thisDirection;
        private int x;
        private int y;
        public VectorObject(int x, int y, direction dir) : base(x, y)
        {
            this.x = x;
            this.y = y;
            thisDirection = dir;
        }

        
        public direction CurrentDirection { get { return thisDirection; } set { thisDirection = value; } }

        public Point nextPosition()
        {
            return new Point(x, y);
        }
    }
}
