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
        public LinkedList<Body> snake;
        private int xInd, yInd;
        public Snake(int xInd, int yInd, direction dir, int indx) : base(xInd*25, yInd*25, dir)
        {
            snake = new LinkedList<Body>();
            index = indx;
            this.xInd = xInd;
            this.yInd = yInd;
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

        public void CutTail()
        {
            int size = snake.Count;
            snake.Last.Value.X = this.xInd;
            snake.Last.Value.Y = this.yInd;
            snake.Last.Value.UpdateInd();
            snake.AddFirst(snake.Last.Value);
            snake.RemoveLast();
        }
        
        public void AddBody(int length)
        {
            snake.AddFirst(new Body(xInd+length, yInd, index++));
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(new Point(xInd*25+1, yInd*25+1), new Size(24, 24)));
        }
    }
}
