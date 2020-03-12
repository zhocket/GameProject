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
        Timer time;
        Snake player1;
        Label score;
        private int snakeLength, points;
        public void Initialize()
        {
            window = new MainForm();
            time = new Timer();
            time.Tick += TimerEventHandler;
            window.Paint += Draw;
            window.KeyDown += KeyPressed;
            time.Interval = 150;
            time.Start();

            score = new Label();
            board = new GameBoard(0, 0, 16, 20);
            player1 = new Snake(8, 10, VectorObject.direction.left, 0);
            player1.CurrentDirection = VectorObject.direction.left;

            points = 0;
            snakeLength = 5;
            for (int i = 0; i < snakeLength; i++)
                player1.AddBody(snakeLength-i);
            board.AddFood();
            
            score.Text = "Score: " + points.ToString();
            score.Font = new Font("Calibri", 16);
            score.Location = new Point(20, 16*25 + 5);
            score.Visible = true;
            score.ForeColor = Color.Black;
            score.Refresh();
            window.Controls.Add(score);

            Application.Run(window);
        }

        public void Run()
        {
            
            player1.CutTail();
            player1.Move(player1.CurrentDirection);
            if(player1.CheckCollision(board.foodList[0].X, board.foodList[0].Y) == true)
            {
                points++;
                board.foodList.Remove(board.foodList[0]);
                player1.AddBody(0);
                snakeLength++;
                board.AddFood();
                score.Text = "Score: " + points.ToString();
            }

        }

        private void TimerEventHandler(object sender, EventArgs e)
        {
            Run();
            window.Refresh();
            score.Refresh();
        }

        public void Draw(Object obj, PaintEventArgs pe)
        {
            board.Draw(pe.Graphics);
            player1.Draw(pe.Graphics);
            
            foreach (Body body in player1.snake)
                body.Draw(pe.Graphics);
            foreach (Food foodItem in board.foodList)
                foodItem.Draw(pe.Graphics);
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
