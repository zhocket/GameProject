using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeProject
{
    class MainForm : Form
    {
        public MainForm() : base(){
            Height = 480;
            Width = 560;
            //BackColor = Color.Purple;
            Text = "Snake Game";
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }
    }
}
