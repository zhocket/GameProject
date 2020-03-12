using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeProject
{
    class GameBoard : GameObject
    {
        private GameObject[,] board;
        private int width;
        private int height;
        public List<Food> foodList;
        public GameBoard(int x, int y, int height, int width) : base(x, y)
        {
            board = new GameObject[width, height];
            this.width = width*25;
            this.height = height*25;
            foodList = new List<Food>();
        }

        public GameObject[,] Matrix { get { return board; } }

        public void AddFood()
        {
            Random rndm = new Random();
            foodList.Add(new Food(rndm.Next(1, width/25), rndm.Next(1, height/25)));
        }

        public override void Draw(Graphics g)
        {
            for (int ix = 0; ix < width+1; ix += 24)
            {
                g.DrawLine(new Pen(Color.DarkGray, 1), ix, 0, ix, height);
                ix += 1;
                for(int iy = 0; iy < height+1; iy += 24)
                {
                    g.DrawLine(new Pen(Color.DarkGray, 1), 0, iy, width, iy);
                    iy += 1;
                }
            }
        }
    }
}
