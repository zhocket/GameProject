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
        GameBoard board;
        Snake player1;
        public void Initialize()
        {
            window = new MainForm();
            Timer time = new Timer();
            time.Tick += TimerEventHandler;
            window.Paint += Draw;
            window.KeyDown += KeyPressed;
            time.Interval = 250;
            time.Start();
            board = new GameBoard(0, 0, 16, 20);
            player1 = new Snake(8, 10, VectorObject.direction.left, 0);
            player1.CurrentDirection = VectorObject.direction.left;
            Application.Run(window);
        }

        public void Run()
        {
            player1.Move(player1.CurrentDirection);
        }

        private void TimerEventHandler(object sender, EventArgs e)
        {
            Run();
            window.Refresh();
        }

        public void Draw(Object obj, PaintEventArgs pe)
        {
            board.Draw(pe.Graphics);
            player1.Draw(pe.Graphics);
        }
        public void KeyPressed(object obj, KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.Left:
                    player1.CurrentDirection = VectorObject.direction.left;
                    break;
                case Keys.Right:
                    player1.CurrentDirection = VectorObject.direction.right;
                    break;
                case Keys.Up:
                    player1.CurrentDirection = VectorObject.direction.up;
                    break;
                case Keys.Down:
                    player1.CurrentDirection = VectorObject.direction.down;
                    break;
            }
        }

    }
}
