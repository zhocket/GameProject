using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeProject
{
    class gameBoard:PhysicalObject
    {
        int x, y;
        public gameBoard(int _x, int _y) : base(_x, _y)
        {
            x = _x;
            y = _y;
        }
        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
