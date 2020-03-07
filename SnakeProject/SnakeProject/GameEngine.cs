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
        int sizeMatrix, i, j;
        int[,] matrix;
        int DirectionX = 0, DirectionY = 1;
        int snakeX = 4, snakeY = 4;
        int Tail;
        MainForm window;
        public void Initialize()
        {
            window = new MainForm();
            Timer time = new Timer();
            time.Tick += TimerEventHandler;

            time.Interval = 1000;/* / 25;*/
            time.Start();
            sizeMatrix = 10;
            matrix = new int[sizeMatrix, sizeMatrix];



            Application.Run(window);
        }
        enum SteerSnake
        {
            Left,
            Right,
            Up,
            Down
        }
        public void SnakeMove()
        {
            snakeX += DirectionX;
            snakeY += DirectionY;
            matrix[snakeX, snakeY] = 3;
            Tail = 2;

            for (i = 0; i < sizeMatrix; i++)
            {
                for (j = 0; j < sizeMatrix; j++)
                {
                    if (matrix[i, j] == Tail)
                        matrix[i, j] = 0;
                }
            }
        }
        public void Run()
        {
            window.Paint += Draw;
            window.KeyDown += KeyPress;
            window.Refresh();
        }
        void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine($"[KeyPress] {e.KeyChar}");
        }
        private void TimerEventHandler(object sender, EventArgs e)
        {
            SnakeMove();
            
            Run();
        }

        public void KeyPress(Object obj, KeyEventArgs a)
        {
            if (a.KeyCode == Keys.Up)
            {
                DirectionX = 0;
                DirectionY = -1;
            }
            if (a.KeyCode == Keys.Down)
            {
                DirectionX = 0;
                DirectionY = 1;
            }
            if (a.KeyCode == Keys.Left)
            {
                DirectionY = 0;
                DirectionX = -1;
            }
            if (a.KeyCode == Keys.Right)
            {
                DirectionY = 0;
                DirectionX = 1;
            }
        }
        public void Draw(Object obj, PaintEventArgs pe)
        {

            for(i = 0; i < sizeMatrix; i++)
            {
                for(j = 0; j < sizeMatrix; j++)
                {
                    if (matrix[i, j] == 0)
                        pe.Graphics.FillRectangle(Brushes.White, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if (matrix[i, j] == 1)
                        pe.Graphics.FillRectangle(Brushes.Green, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if(matrix[i,j]==2)
                        pe.Graphics.FillRectangle(Brushes.Magenta, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if(matrix[i,j]==3)
                        pe.Graphics.FillRectangle(Brushes.Black, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                }
            }
        }

    }
}
