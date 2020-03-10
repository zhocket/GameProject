using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeProject
{
    static class Program
    {

        static void Main()
        {
            GameEngine engine = new GameEngine();
            engine.Initialize();
        }
    }
}
