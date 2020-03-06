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
        int x = 50, y = 50, z = 6, k = 6;
        MainForm window;
        public void Initialize()
        {
            window = new MainForm();
            Timer time = new Timer();
            time.Tick += TimerEventHandler;

            time.Interval = 1000 / 25;
            time.Start();

            Application.Run(window);
        }

        public void Run()
        {
            
        }

        private void TimerEventHandler(object sender, EventArgs e)
        {

            window.Paint += Draw;
            window.Refresh();
        }

        public void Draw(Object obj, PaintEventArgs pe)
        {
            pe.Graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(x++, y++, z--, k));
        }

    }
}
