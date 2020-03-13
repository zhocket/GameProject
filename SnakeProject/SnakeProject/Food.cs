using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Food : PhysicalObject
    {
        private int x, y;
        private Brush color;
        public Food(int xInd, int yInd, Brush brush) : base(xInd, yInd)
        {
            x = xInd;
            y = yInd;
            color = brush;
        }
        public Brush Color { get { return color; } set { color = value; } }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(color, new Rectangle(new Point(x * 25 + 1, y * 25 + 1), new Size(24, 24)));

        }
    }
}
