using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Snake : VectorObject
    {
        private int index;
        private List<Body> snake;
        private int xInd, yInd;
        public Snake(int xInd, int yInd, direction dir, int indx) : base(xInd*25, yInd*25, dir)
        {
            snake = new List<Body>();
            index = indx;
            this.xInd = xInd;
            this.yInd = yInd;
            snake.Add(new Body(xInd, yInd, index));
        }

        public void Move(direction thisDirection)
        {
            switch (thisDirection)
            {
                case direction.left:
                    xInd -= 1;
                    break;
                case direction.right:
                    xInd += 1;
                    break;
                case direction.up:
                    yInd -= 1;
                    break;
                case direction.down:
                    yInd += 1;
                    break;
            }
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(new Point(xInd*25+1, yInd*25+1), new Size(24, 24)));
        }
    }
}
