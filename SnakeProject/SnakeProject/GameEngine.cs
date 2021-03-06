﻿using System;
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


        }
        public void KeyPressed(Object obj, KeyEventArgs key)
        {

        }

    }
}
