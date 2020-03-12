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
        private int xPosition;
        private int yPosition;
        public Body(int xInd, int yInd, int index) : base(xInd*25, yInd*25)
        {
            this.index = index;
            xPosition = xInd * 25;
            yPosition = yInd * 25;
        }

        public int Index { get { return index; } set { index = value; } }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
