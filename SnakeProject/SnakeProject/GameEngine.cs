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
        int x = 50, y = 50, z = 6;
        int sizeMatrix;

        MainForm window;
        public void Initialize()
        {
            window = new MainForm();
            Timer time = new Timer();
            time.Tick += TimerEventHandler;

            time.Interval = 1000 / 25;
            time.Start();
            sizeMatrix = 10;

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
            pe.Graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(x, y, z, z));

            for(int i = 0; i < sizeMatrix; i++)
            {
                for(int j = 0; j < sizeMatrix; j++)
                {
                    pe.Graphics.FillRectangle(Brushes.White, i * (840 / sizeMatrix)+1, j * (640 / sizeMatrix)+1, (840/sizeMatrix)-2, (640/sizeMatrix)-2);
                }
            }
        }

    }
}
