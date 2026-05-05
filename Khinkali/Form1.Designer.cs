namespace Khinkali
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblScore = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGameOver = new System.Windows.Forms.Panel();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnGameOverMenu = new System.Windows.Forms.Button();
            this.btnGameOverScores = new System.Windows.Forms.Button();
            this.btnGameOverRestart = new System.Windows.Forms.Button();
            this.lblGameOverDifficulty = new System.Windows.Forms.Label();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.lblGameOverTitle = new System.Windows.Forms.Label();
            this.pnlPause = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbFlyKnife = new System.Windows.Forms.PictureBox();
            this.pbFlyFork = new System.Windows.Forms.PictureBox();
            this.pbGroundFork = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.pbGroundForkKnife = new System.Windows.Forms.PictureBox();
            this.pbGroundKnife = new System.Windows.Forms.PictureBox();
            this.pbCoin = new System.Windows.Forms.PictureBox();
            this.pnlGameOver.SuspendLayout();
            this.pnlPause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlyKnife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlyFork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundFork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundForkKnife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundKnife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCoin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(145, 25);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(88, 25);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "Score : ";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlGameOver.BackgroundImage = global::Khinkali.Properties.Resources.GeneralBG;
            this.pnlGameOver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlGameOver.Controls.Add(this.lblPlayerName);
            this.pnlGameOver.Controls.Add(this.btnGameOverMenu);
            this.pnlGameOver.Controls.Add(this.btnGameOverScores);
            this.pnlGameOver.Controls.Add(this.btnGameOverRestart);
            this.pnlGameOver.Controls.Add(this.lblGameOverDifficulty);
            this.pnlGameOver.Controls.Add(this.lblBestScore);
            this.pnlGameOver.Controls.Add(this.lblFinalScore);
            this.pnlGameOver.Controls.Add(this.lblGameOverTitle);
            this.pnlGameOver.Location = new System.Drawing.Point(263, 25);
            this.pnlGameOver.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(551, 448);
            this.pnlGameOver.TabIndex = 13;
            this.pnlGameOver.Visible = false;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblPlayerName.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(59, 118);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(158, 29);
            this.lblPlayerName.TabIndex = 7;
            this.lblPlayerName.Text = "Player Name:";
            this.lblPlayerName.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnGameOverMenu
            // 
            this.btnGameOverMenu.BackColor = System.Drawing.Color.Maroon;
            this.btnGameOverMenu.FlatAppearance.BorderSize = 0;
            this.btnGameOverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameOverMenu.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameOverMenu.ForeColor = System.Drawing.Color.Wheat;
            this.btnGameOverMenu.Location = new System.Drawing.Point(389, 351);
            this.btnGameOverMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnGameOverMenu.Name = "btnGameOverMenu";
            this.btnGameOverMenu.Size = new System.Drawing.Size(97, 28);
            this.btnGameOverMenu.TabIndex = 6;
            this.btnGameOverMenu.Text = "Menu";
            this.btnGameOverMenu.UseVisualStyleBackColor = false;
            this.btnGameOverMenu.Click += new System.EventHandler(this.btnGameOverMenu_Click);
            // 
            // btnGameOverScores
            // 
            this.btnGameOverScores.BackColor = System.Drawing.Color.Maroon;
            this.btnGameOverScores.FlatAppearance.BorderSize = 0;
            this.btnGameOverScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameOverScores.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameOverScores.ForeColor = System.Drawing.Color.Wheat;
            this.btnGameOverScores.Location = new System.Drawing.Point(204, 351);
            this.btnGameOverScores.Margin = new System.Windows.Forms.Padding(4);
            this.btnGameOverScores.Name = "btnGameOverScores";
            this.btnGameOverScores.Size = new System.Drawing.Size(139, 28);
            this.btnGameOverScores.TabIndex = 5;
            this.btnGameOverScores.Text = " Scores";
            this.btnGameOverScores.UseVisualStyleBackColor = false;
            this.btnGameOverScores.Click += new System.EventHandler(this.btnGameOverScore_Click);
            // 
            // btnGameOverRestart
            // 
            this.btnGameOverRestart.BackColor = System.Drawing.Color.Maroon;
            this.btnGameOverRestart.FlatAppearance.BorderSize = 0;
            this.btnGameOverRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameOverRestart.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameOverRestart.ForeColor = System.Drawing.Color.Wheat;
            this.btnGameOverRestart.Location = new System.Drawing.Point(64, 351);
            this.btnGameOverRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnGameOverRestart.Name = "btnGameOverRestart";
            this.btnGameOverRestart.Size = new System.Drawing.Size(100, 28);
            this.btnGameOverRestart.TabIndex = 4;
            this.btnGameOverRestart.Text = "Restart";
            this.btnGameOverRestart.UseVisualStyleBackColor = false;
            this.btnGameOverRestart.Click += new System.EventHandler(this.btnGameOverRestart_Click);
            // 
            // lblGameOverDifficulty
            // 
            this.lblGameOverDifficulty.AutoSize = true;
            this.lblGameOverDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblGameOverDifficulty.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverDifficulty.Location = new System.Drawing.Point(59, 295);
            this.lblGameOverDifficulty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameOverDifficulty.Name = "lblGameOverDifficulty";
            this.lblGameOverDifficulty.Size = new System.Drawing.Size(121, 29);
            this.lblGameOverDifficulty.TabIndex = 3;
            this.lblGameOverDifficulty.Text = "Difficulty:";
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblBestScore.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestScore.Location = new System.Drawing.Point(59, 231);
            this.lblBestScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(179, 29);
            this.lblBestScore.TabIndex = 2;
            this.lblBestScore.Text = "The Best Score:";
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFinalScore.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalScore.Location = new System.Drawing.Point(59, 176);
            this.lblFinalScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(80, 29);
            this.lblFinalScore.TabIndex = 1;
            this.lblFinalScore.Text = "Score:";
            // 
            // lblGameOverTitle
            // 
            this.lblGameOverTitle.AutoSize = true;
            this.lblGameOverTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblGameOverTitle.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblGameOverTitle.Location = new System.Drawing.Point(195, 57);
            this.lblGameOverTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameOverTitle.Name = "lblGameOverTitle";
            this.lblGameOverTitle.Size = new System.Drawing.Size(166, 42);
            this.lblGameOverTitle.TabIndex = 0;
            this.lblGameOverTitle.Text = "GAME OVER";
            // 
            // pnlPause
            // 
            this.pnlPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlPause.BackgroundImage = global::Khinkali.Properties.Resources.GeneralBG;
            this.pnlPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPause.Controls.Add(this.btnExit);
            this.pnlPause.Controls.Add(this.btnReplay);
            this.pnlPause.Controls.Add(this.btnResume);
            this.pnlPause.Controls.Add(this.label1);
            this.pnlPause.Location = new System.Drawing.Point(392, 116);
            this.pnlPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPause.Name = "pnlPause";
            this.pnlPause.Size = new System.Drawing.Size(308, 261);
            this.pnlPause.TabIndex = 12;
            this.pnlPause.Visible = false;
            this.pnlPause.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPause_Paint);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Maroon;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Wheat;
            this.btnExit.Location = new System.Drawing.Point(101, 178);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 34);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.BackColor = System.Drawing.Color.Maroon;
            this.btnReplay.FlatAppearance.BorderSize = 0;
            this.btnReplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplay.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplay.ForeColor = System.Drawing.Color.Wheat;
            this.btnReplay.Location = new System.Drawing.Point(103, 137);
            this.btnReplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(100, 37);
            this.btnReplay.TabIndex = 2;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.Maroon;
            this.btnResume.FlatAppearance.BorderSize = 0;
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.Wheat;
            this.btnResume.Location = new System.Drawing.Point(101, 98);
            this.btnResume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(101, 33);
            this.btnResume.TabIndex = 1;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAUSED";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(35)))), ((int)(((byte)(14)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 446);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1168, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbFlyKnife
            // 
            this.pbFlyKnife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbFlyKnife.BackgroundImage = global::Khinkali.Properties.Resources.FlyKnife;
            this.pbFlyKnife.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFlyKnife.Location = new System.Drawing.Point(833, 310);
            this.pbFlyKnife.Margin = new System.Windows.Forms.Padding(4);
            this.pbFlyKnife.Name = "pbFlyKnife";
            this.pbFlyKnife.Size = new System.Drawing.Size(72, 69);
            this.pbFlyKnife.TabIndex = 11;
            this.pbFlyKnife.TabStop = false;
            this.pbFlyKnife.Tag = "obstacle";
            // 
            // pbFlyFork
            // 
            this.pbFlyFork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbFlyFork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbFlyFork.BackgroundImage")));
            this.pbFlyFork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFlyFork.Location = new System.Drawing.Point(613, 310);
            this.pbFlyFork.Margin = new System.Windows.Forms.Padding(4);
            this.pbFlyFork.Name = "pbFlyFork";
            this.pbFlyFork.Size = new System.Drawing.Size(67, 69);
            this.pbFlyFork.TabIndex = 10;
            this.pbFlyFork.TabStop = false;
            this.pbFlyFork.Tag = "obstacle";
            // 
            // pbGroundFork
            // 
            this.pbGroundFork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbGroundFork.Image = ((System.Drawing.Image)(resources.GetObject("pbGroundFork.Image")));
            this.pbGroundFork.Location = new System.Drawing.Point(512, 382);
            this.pbGroundFork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbGroundFork.Name = "pbGroundFork";
            this.pbGroundFork.Size = new System.Drawing.Size(35, 91);
            this.pbGroundFork.TabIndex = 6;
            this.pbGroundFork.TabStop = false;
            this.pbGroundFork.Tag = "obstacle";
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbPlayer.Image = global::Khinkali.Properties.Resources.KhinkaliRunning;
            this.pbPlayer.Location = new System.Drawing.Point(141, 346);
            this.pbPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(99, 96);
            this.pbPlayer.TabIndex = 9;
            this.pbPlayer.TabStop = false;
            // 
            // pbGroundForkKnife
            // 
            this.pbGroundForkKnife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbGroundForkKnife.Image = global::Khinkali.Properties.Resources.forkKnife;
            this.pbGroundForkKnife.Location = new System.Drawing.Point(756, 382);
            this.pbGroundForkKnife.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbGroundForkKnife.Name = "pbGroundForkKnife";
            this.pbGroundForkKnife.Size = new System.Drawing.Size(57, 91);
            this.pbGroundForkKnife.TabIndex = 8;
            this.pbGroundForkKnife.TabStop = false;
            this.pbGroundForkKnife.Tag = "obstacle";
            // 
            // pbGroundKnife
            // 
            this.pbGroundKnife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbGroundKnife.Image = global::Khinkali.Properties.Resources.knife;
            this.pbGroundKnife.Location = new System.Drawing.Point(961, 382);
            this.pbGroundKnife.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbGroundKnife.Name = "pbGroundKnife";
            this.pbGroundKnife.Size = new System.Drawing.Size(32, 91);
            this.pbGroundKnife.TabIndex = 7;
            this.pbGroundKnife.TabStop = false;
            this.pbGroundKnife.Tag = "obstacle";
            // 
            // pbCoin
            // 
            this.pbCoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbCoin.BackgroundImage = global::Khinkali.Properties.Resources.coin;
            this.pbCoin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCoin.Location = new System.Drawing.Point(833, 392);
            this.pbCoin.Name = "pbCoin";
            this.pbCoin.Size = new System.Drawing.Size(35, 35);
            this.pbCoin.TabIndex = 14;
            this.pbCoin.TabStop = false;
            this.pbCoin.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::Khinkali.Properties.Resources.wall4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 505);
            this.Controls.Add(this.pbCoin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.pnlPause);
            this.Controls.Add(this.pbFlyKnife);
            this.Controls.Add(this.pbFlyFork);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbGroundFork);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbGroundForkKnife);
            this.Controls.Add(this.pbGroundKnife);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Tag = "obstacle";
            this.Text = "KhinkaliGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameKeyUp);
            this.pnlGameOver.ResumeLayout(false);
            this.pnlGameOver.PerformLayout();
            this.pnlPause.ResumeLayout(false);
            this.pnlPause.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlyKnife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlyFork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundFork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundForkKnife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroundKnife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.PictureBox pbGroundForkKnife;
        private System.Windows.Forms.PictureBox pbGroundKnife;
        private System.Windows.Forms.PictureBox pbGroundFork;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox pbFlyFork;
        private System.Windows.Forms.PictureBox pbFlyKnife;
        private System.Windows.Forms.Panel pnlPause;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlGameOver;
        private System.Windows.Forms.Button btnGameOverMenu;
        private System.Windows.Forms.Button btnGameOverScores;
        private System.Windows.Forms.Button btnGameOverRestart;
        private System.Windows.Forms.Label lblGameOverDifficulty;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.Label lblGameOverTitle;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.PictureBox pbCoin;
    }
}

