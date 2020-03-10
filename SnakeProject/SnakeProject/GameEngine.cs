using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeProject
{
    class GameEngine
    {
        MainForm window;
        Timer time;
        List<GameObject> Objects;

        Snake PlayerOne;

        public GameEngine()
        {
            window = new MainForm();
            time = new Timer();
            Objects = new List<GameObject>();

            PlayerOne = new Snake(5, 5);
        }

        public void Initialize()
        {
            window.Paint += Draw;

            time.Tick += Time_Tick;

            time.Interval = 1000;
            time.Start();

            //RealTime();

            Application.Run(window);
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            window.Refresh();
        }

        private void Draw(Object obj, PaintEventArgs args)
        {

            foreach (var square in Objects)
            {
                square.Draw(args.Graphics);

            }
        }

    }
}
