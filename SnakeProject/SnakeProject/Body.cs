using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeProject
{
    class Body : PhysicalObject
    {
        private int index;
        private int xInd;
        private int yInd;
        public Body(int xInd, int yInd, int index) : base(xInd, yInd)
        {
            this.index = index;
            this.xInd = xInd;
            this.yInd = yInd;
        }

        public int Index { get { return index; } set { index = value; } }

        public void UpdateInd()
        {
            xInd = this.X;
            yInd = this.Y;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(new Point(xInd * 25 + 1, yInd * 25 + 1), new Size(24, 24)));
        }
    }
}
