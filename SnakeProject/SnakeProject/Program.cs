﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        [STAThread]

        
        static void Main()
        {
            GameEngine engine = new GameEngine();
            engine.StartMenu();
        }
    }
}
