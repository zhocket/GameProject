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
        private float speed;
        public VectorObject(int x, int y, string direct, float speed) : base(x, y)
        {
            thisDirection = (direction) Enum.Parse(typeof(direction), direct);
            this.speed = speed;
        }

        
        public direction CurrentDirection { get { return thisDirection; } set { thisDirection = value; } }

        public Point nextPosition(int x, int y)
        {
            return new Point(x, y);
        }
    }
}
