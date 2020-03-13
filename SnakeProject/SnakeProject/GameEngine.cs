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
                player2.AddBody(-snakeLength2-i);

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

        public void EndGame(Snake player, Label score, int points)
        {
            time.Stop();
            if(player.color == Brushes.Red)
                 score.Text = "GAME OVER \n" + "Red player " + "wins!\nScore: " + points.ToString() + "\n\n[ESC] back to menu ";
            if (player.color == Brushes.LimeGreen)
                score.Text = "GAME OVER \n" + "Green player " + "wins!\nScore: " + points.ToString() + "\n\n[ESC] back to menu ";
            score.AutoSize = true;
            score.Location = new Point(window.Width / 2 - 80, window.Height / 2 - score.Height);
            if (player.color == Brushes.Red)
                score.BackColor = Color.LightSalmon;
            else
                score.BackColor = Color.LightGreen;
            score.BorderStyle = BorderStyle.FixedSingle;
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
                EndGame(player1, score1, points1);
            }
            if(player1.OutOfBounds() == true)
            {
                EndGame(player2, score2, points2);
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

            //Green player collide with red
            foreach (Body body in player1.snake)
            {
                if (player2.CheckCollision(body.X, body.Y) || player2.CheckCollision(player1.X, player1.Y))
                    EndGame(player1, score1, points1);
                if (player1.CheckCollision(body.X, body.Y) && body != player1.snake.First.Value && body != player1.snake.First.Next.Value)
                    EndGame(player2, score2, points2);
                
            }
            

            //Red player collide with green
            foreach (Body body in player2.snake)
            {
                if (player1.CheckCollision(body.X, body.Y) || player1.CheckCollision(player2.X, player2.Y))
                    EndGame(player2, score2, points2);
                if (player2.CheckCollision(body.X, body.Y) && body != player2.snake.First.Value && body != player2.snake.First.Next.Value)
                    EndGame(player1, score1, points1);
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
                    if(player1.CurrentDirection != VectorObject.direction.right)
                       player1.CurrentDirection = VectorObject.direction.left;
                    break;
                case Keys.Right:
                    if (player1.CurrentDirection != VectorObject.direction.left)
                        player1.CurrentDirection = VectorObject.direction.right;
                    break;
                case Keys.Up:
                    if (player1.CurrentDirection != VectorObject.direction.down)
                        player1.CurrentDirection = VectorObject.direction.up;
                    break;
                case Keys.Down:
                    if (player1.CurrentDirection != VectorObject.direction.up)
                        player1.CurrentDirection = VectorObject.direction.down;
                    break;
            }
            switch (key.KeyCode)
            {
                case Keys.A:
                    if (player2.CurrentDirection != VectorObject.direction.right)
                        player2.CurrentDirection = VectorObject.direction.left;
                    break;
                case Keys.D:
                    if (player2.CurrentDirection != VectorObject.direction.left)
                        player2.CurrentDirection = VectorObject.direction.right;
                    break;
                case Keys.W:
                    if (player2.CurrentDirection != VectorObject.direction.down)
                        player2.CurrentDirection = VectorObject.direction.up;
                    break;
                case Keys.S:
                    if (player2.CurrentDirection != VectorObject.direction.up)
                        player2.CurrentDirection = VectorObject.direction.down;
                    break;
            }
            if (key.KeyCode == Keys.Escape)
                this.window.Close();
        }

    }
}
