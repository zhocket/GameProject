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
        int sizeMatrix;
        int[,] matrix;
        int startX = 5, startY = 5;
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

        public void Snake()
        {
            matrix[5, 5] = 1;
            matrix[6, 5] = 2;
            matrix[startX, startY] = 3;
        }
        public void Run()
        {
            
        }
        void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine($"[KeyPress] {e.KeyChar}");
        }
        private void TimerEventHandler(object sender, EventArgs e)
        {
            Snake();

            startX++;
            window.Paint += Draw;
            window.KeyDown += KeyPress;
            window.Refresh();
        }

        public void KeyPress(Object obj, KeyEventArgs a)
        {
            if (a.KeyCode == Keys.Up)
            {
                startY--;
            }
            if (a.KeyCode == Keys.Left)
            {
                startX--;
            }
        }
        public void Draw(Object obj, PaintEventArgs pe)
        {
            //pe.Graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(x, y, z, z));

            for(int i = 0; i < sizeMatrix; i++)
            {
                for(int j = 0; j < sizeMatrix; j++)
                {
                    if (matrix[i, j] == 0)
                        pe.Graphics.FillRectangle(Brushes.White, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if (matrix[i, j] == 1)
                        pe.Graphics.FillRectangle(Brushes.Green, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if(matrix[i,j]==2)
                        pe.Graphics.FillRectangle(Brushes.Black, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                    else if(matrix[i,j]==3)
                        pe.Graphics.FillRectangle(Brushes.Magenta, i * (840 / sizeMatrix) + 1, j * (640 / sizeMatrix) + 1, (840 / sizeMatrix) - 2, (640 / sizeMatrix) - 2);
                }
            }
        }

    }
}
