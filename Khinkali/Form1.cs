using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Khinkali
{
    public partial class Form1 : Form
    {
        int score = 0;
        bool isJumping = false;
        bool gameOver = false;

        int verticalSpeed = 0;
        int obstacleSpeed = 8;

        int groundY = 385;

        bool counted3 = false;
        bool counted4 = false;
        bool counted5 = false;


        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += GameKeyDown;
            this.KeyUp += GameKeyUp;

            GameReset();
            GameTimer.Start();
        }


        private void GameTimerEvent(object sender, EventArgs e)
        {

            if (gameOver) return;

            lblScore.Text = "Score: " + score;

            if (isJumping)
            {
                Khinkali.Top += verticalSpeed;
                verticalSpeed += 1;

                if (Khinkali.Top >= groundY)
                {
                    Khinkali.Top = groundY;
                    isJumping = false;
                    verticalSpeed = 0;
                  
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x != Khinkali && x.Tag != null && x.Tag.ToString() == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    Rectangle playerHitBox = new Rectangle(
                        Khinkali.Left + 15,
                        Khinkali.Top + 10,
                        Khinkali.Width - 30,
                        Khinkali.Height - 10
                    );

                    Rectangle obstacleHitBox = new Rectangle(
                        x.Left + 5,
                        x.Top + 5,
                        x.Width - 10,
                        x.Height - 10
                    );

                    if (playerHitBox.IntersectsWith(obstacleHitBox))
                    {
                        gameOver = true;
                        GameTimer.Stop();
                        lblScore.Text = "Score: " + score + "   Game Over";
                    }

                    if (x == pictureBox3 && !counted3 && x.Right < Khinkali.Left)
                    {
                        score++;
                        counted3 = true;
                    }

                    if (x == pictureBox4 && !counted4 && x.Right < Khinkali.Left)
                    {
                        score++;
                        counted4 = true;
                    }

                    if (x == pictureBox5 && !counted5 && x.Right < Khinkali.Left)
                    {
                        score++;
                        counted5 = true;
                    }

                    if (x.Left < -100)
                    {
                        int farthestX = Math.Max(pictureBox3.Left, Math.Max(pictureBox4.Left, pictureBox5.Left));
                        x.Left = farthestX + random.Next(300, 500);

                        if (x == pictureBox3) counted3 = false;
                        if (x == pictureBox4) counted4 = false;
                        if (x == pictureBox5) counted5 = false;
                    }
                }
            }
        }



        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver && e.KeyCode == Keys.Enter)
            {
                GameReset();
                GameTimer.Start();
                return;
            }

            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = true;
                verticalSpeed = -18;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GameReset()
        {
            score = 0;
            isJumping = false;
            gameOver = false;
            verticalSpeed = 0;
            
            obstacleSpeed = 8;

            lblScore.Text = "Score: " + score;
            Khinkali.Image = Properties.Resources.KhinkaliRunning;

            Khinkali.Top = groundY;
            Khinkali.Left = 186;

            pictureBox5.Left = 600;
            pictureBox3.Left = 950;
            pictureBox4.Left = 1300;


            pictureBox5.Tag = "obstacle";
            pictureBox3.Tag = "obstacle";
            pictureBox4.Tag = "obstacle";


            GameTimer.Start();
        }

      
    }
}

