using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    abstract class VectorObject:PhysicalObject
    {
        private int x;
        private int y;

        public VectorObject(int _x, int _y) : base(_x, _y)
        {
            x = _x;
            y = _y;
        }

    }
}
