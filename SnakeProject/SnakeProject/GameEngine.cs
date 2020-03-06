using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeProject
{
    class GameEngine
    {
        public void Initialize()
        {
            MainForm window = new MainForm();
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
            
        }

    }
}
