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
        public Food(int xInd, int yInd) : base(xInd, yInd)
        {
            x = xInd;
            y = yInd;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow, new Rectangle(new Point(x * 25 + 1, y * 25 + 1), new Size(24, 24)));

        }
    }
}
