using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeProject
{
    class Menu
    {
        Button button;
        public void Start(MainForm window)
        {
            button = new Button();
            window.BackgroundImage = Properties.Resources.snake_sprite;
            button.Location = new Point(120, 215);
            button.Size = new Size(315, 72);
            button.ForeColor = Color.Transparent;
            button.BackColor = Color.Transparent;

            window.Controls.Add(button);
            button.Click += Button_Click;
            Application.Run(window);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            GameEngine engine = new GameEngine();
            engine.Initialize();
        }
    }
}
