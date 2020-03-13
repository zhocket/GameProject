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
        public Brush color;
        public Snake(int xInd, int yInd, direction dir, int indx, Brush color) : base(xInd*25, yInd*25, dir)
        {
            snake = new LinkedList<Body>();
            index = indx;
            this.CurrentDirection = dir;
            this.xInd = xInd;
            this.yInd = yInd;
            this.color = color;
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
            this.X = xInd;
            this.Y = yInd;
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

        public int CheckForFood(Food fooditem, GameBoard board, int points)
        {
            points = 0;
            if (this.CheckCollision(fooditem.X, fooditem.Y) == true && fooditem.Color == Brushes.CornflowerBlue)
            {
                
                board.foodList.Remove(fooditem);
                AddBody(0);
                board.AddFood(new Random(), 1, 1, Brushes.CornflowerBlue);
                return ++points;
            }
            else if (this.CheckCollision(fooditem.X, fooditem.Y) == true && fooditem.Color == Brushes.Purple)
            {
                board.foodList.Remove(fooditem);
                AddBody(0);
                AddBody(0);
                board.AddFood(new Random(), 1, 1, Brushes.Purple);
                return points += 5;
            }
            else if (this.CheckCollision(fooditem.X, fooditem.Y) == true && fooditem.Color == Brushes.LightBlue)
            {
                board.foodList.Remove(fooditem);
                snake.RemoveLast();
                board.AddFood(new Random(), 1, 1, Brushes.LightBlue);
                return ++points;
            }
            return 0;
        }
        
        public void AddBody(int length)
        {
            snake.AddFirst(new Body(xInd+length, yInd, index++));
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(color, new Rectangle(new Point(xInd*25+1, yInd*25+1), new Size(24, 24)));
        }
    }
}
