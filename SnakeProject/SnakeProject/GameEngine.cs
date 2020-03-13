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
        Snake player1, player2;
        Label score1, score2;
        private int snakeLength1, snakeLength2;
        private int points1, points2;

        public void Initialize()
        {
            window = new MainForm();
            time = new Timer();
            time.Tick += TimerEventHandler;
            window.Paint += Draw;
            window.KeyDown += KeyPressed;
            time.Interval = 100;
            time.Start();
            window.BackColor = Color.Black;


            score1 = new Label();
            score2 = new Label();
            board = new GameBoard(0, 0, 16, 20);
            player1 = new Snake(8, 10, VectorObject.direction.left, 0, Brushes.Red);
            player2 = new Snake(4, 6, VectorObject.direction.right, 0, Brushes.LimeGreen);

            points1 = 0;
            points2 = 0;
            snakeLength1 = 5;
            snakeLength2 = 5;
            for (int i = 0; i < snakeLength1; i++)
                player1.AddBody(snakeLength1-i);
            for (int i = 0; i < snakeLength2; i++)
                player2.AddBody(snakeLength2 - i);

            board.AddFood(new Random(), 2, 6, Brushes.CornflowerBlue);
            board.AddFood(new Random(), 1, 3, Brushes.Purple);
            board.AddFood(new Random(), 3, 5, Brushes.LightBlue);



            score1.Text = "P1: " + points1.ToString();
            score1.Font = new Font("Calibri", 16, FontStyle.Bold);
            score1.Location = new Point(4, 4);
            score1.Visible = true;
            score1.ForeColor = Color.Red;
            score1.BackColor = Color.Transparent;

            score2.Text = "P2: " + points1.ToString();
            score2.Font = new Font("Calibri", 16, FontStyle.Bold);
            score2.Location = new Point(16*25, 4);
            score2.Visible = true;
            score2.ForeColor = Color.LimeGreen;
            score2.BackColor = Color.Transparent;

            window.Controls.Add(score1);
            window.Controls.Add(score2);

            window.ShowDialog();
        }

        public void StartMenu()
        {
            window = new MainForm();
            Menu menu = new Menu();
            menu.Start(window);
            
        }

        public void Run()
        {
            score1.Text = "P1: " + points1.ToString();
            score2.Text = "P2: " + points2.ToString();

            player1.CutTail();
            player1.Move(player1.CurrentDirection);
            player2.CutTail();
            player2.Move(player2.CurrentDirection);
            if(player2.OutOfBounds() == true)
            {
                time.Stop();
                score1.Text = "GAME OVER \nPlayer 1 wins!\nScore: " + points1.ToString() + "\n\n[ESC] back to menu ";
                score1.AutoSize = true;
                score1.Location = new Point(window.Width / 2 - 80, window.Height / 2 - score1.Height);
                score1.BackColor = Color.LightSalmon;
                score1.BorderStyle = BorderStyle.FixedSingle;
            }
            if(player1.OutOfBounds() == true)
            {
                time.Stop();
                score2.Text = "GAME OVER \nPlayer 2 wins!\nScore: " + points2.ToString() + "\n\n[ESC] back to menu ";
                score2.AutoSize = true;
                score2.Location = new Point(window.Width / 2 - 80, window.Height / 2 - score2.Height);
                score2.BackColor = Color.LightGreen;
                score2.BorderStyle = BorderStyle.FixedSingle;
            }

            foreach (Food fooditem in board.foodList)
            {
                int temp = player1.CheckForFood(fooditem, board, points1);
                if (temp > 0)
                {
                    points1 += temp;
                    break;
                }

            }
            foreach (Food fooditem in board.foodList)
            {
                int temp = player2.CheckForFood(fooditem, board, points2);
                if (temp > 0)
                {
                    points2 += temp;
                    break;
                }
            }

        }

        private void TimerEventHandler(object sender, EventArgs e)
        {
            Run();
            window.Refresh();
            score1.Refresh();
            score2.Refresh();

        }

        public void Draw(Object obj, PaintEventArgs pe)
        {
            board.Draw(pe.Graphics);
            player1.Draw(pe.Graphics);
            player2.Draw(pe.Graphics);
            foreach (Body body in player1.snake)
                body.Draw(pe.Graphics);
            foreach (Body body in player2.snake)
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
            switch (key.KeyCode)
            {
                case Keys.A:
                    player2.CurrentDirection = VectorObject.direction.left;
                    break;
                case Keys.D:
                    player2.CurrentDirection = VectorObject.direction.right;
                    break;
                case Keys.W:
                    player2.CurrentDirection = VectorObject.direction.up;
                    break;
                case Keys.S:
                    player2.CurrentDirection = VectorObject.direction.down;
                    break;
            }
            if (key.KeyCode == Keys.Escape)
                this.window.Close();
        }

    }
}
