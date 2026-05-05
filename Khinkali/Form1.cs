using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Khinkali
{
    public partial class Form1 : Form
    {
        // Lists all possible obstacle types that can appear in the game
        // Makes obstacle selection cleaner than using strings
        private enum ObstacleKind
        {
            GroundFork,
            GroundKnife,
            GroundForkKnife,
            FlyFork,
            FlyKnife
        }

        // Stores the basic game state
        // Keeps track of score, movement, pause, and game over status
        int score = 0;
        bool isJumping = false;
        bool isDucking = false;
        bool downKeyHeld = false;
        bool gameOver = false;
        bool isPaused = false;

        // Stores the coin object and coin settings
        // Coins only appear after the game changes to night mode
        Coin coin;
        int coinValue = 5;
        int coinTopMin = 220;
        int coinTopMax = 340;

        // Stores cheat and testing mode status
        // When testMode is true, the player does not lose from collisions
        bool testMode = false;

        // Stores scene and background mode information
        // The game starts in day mode and changes to night mode at score 50
        string currentScene = "Day";
        int nightScore = 50;

        // Stores jump physics values
        // verticalSpeed controls how fast the player moves up or down
        // jumpPower is negative because moving upward decreases the PictureBox Top value
        int verticalSpeed = 0;
        int jumpPower = -14;
        int gravity = 1;
        int fallGravity = 2;

        // Limits the player to two jumps before landing
        int jumpsMade = 0;
        int maxJumps = 2;

        // Stores normal player size values
        int normalPlayerWidth = 63;
        int normalPlayerHeight = 69;

        // Stores ducking player size values
        int duckPlayerWidth = 73;
        int duckPlayerHeight = 45;
        int duckPlayerTop;

        // Stores difficulty-controlled speed settings
        // These values change depending on Easy, Medium, or Hard mode
        int obstacleSpeed = 6;
        int maxObstacleSpeed = 14;

        bool speedIncreasesOverTime = false;
        int difficultyTimer = 0;
        int speedIncreaseRate = 300;

        // Stores random spacing settings
        // Controls the random distance between obstacles when they reset
        Random random = new Random();
        int minSpacing = 450;
        int maxSpacing = 650;

        // Stores the current obstacle pattern for the selected difficulty
        ObstacleKind[] currentObstaclePattern;
        int currentObstacleIndex = 0;

        // Stores the Easy obstacle pattern
        // Easy only uses ground obstacles
        ObstacleKind[] easyObstaclePattern =
        {
            ObstacleKind.GroundFork,
            ObstacleKind.GroundForkKnife,
            ObstacleKind.GroundKnife
        };

        // Stores the Medium obstacle pattern
        // Medium uses ground obstacles with harder speed and spacing
        ObstacleKind[] mediumObstaclePattern =
        {
            ObstacleKind.GroundFork,
            ObstacleKind.GroundKnife,
            ObstacleKind.GroundForkKnife,
            ObstacleKind.GroundFork,
            ObstacleKind.GroundForkKnife,
            ObstacleKind.GroundKnife
        };

        // Stores the Hard obstacle pattern
        // Hard includes ground and flying obstacles, so the player must jump and duck
        ObstacleKind[] hardObstaclePattern =
        {
            ObstacleKind.GroundFork,
            ObstacleKind.FlyFork,
            ObstacleKind.GroundKnife,
            ObstacleKind.FlyKnife,

            ObstacleKind.FlyKnife,
            ObstacleKind.GroundForkKnife,
            ObstacleKind.FlyFork,
            ObstacleKind.GroundFork,

            ObstacleKind.GroundKnife,
            ObstacleKind.FlyFork,
            ObstacleKind.GroundFork,
            ObstacleKind.FlyKnife,
            ObstacleKind.GroundForkKnife,

            ObstacleKind.FlyFork,
            ObstacleKind.GroundKnife,
            ObstacleKind.FlyKnife,
            ObstacleKind.GroundForkKnife
        };

        // Stores player and obstacle positions
        // Ground and flying obstacles use different vertical positions
        int groundY = 294;
        int groundObstacleTop = 299;
        int flyingObstacleTop = 260;

        // Stores cached obstacle images
        // These images are reused when obstacle slots change type
        Image groundForkImage;
        Image groundKnifeImage;
        Image groundForkKnifeImage;
        Image flyForkImage;
        Image flyKnifeImage;

        // Stores all obstacle objects used during the game
        // Stores GroundObstacle and FlyingObstacle objects as Obstacle objects
        
        List<Obstacle> obstacles = new List<Obstacle>();

        public Form1()
        {
            InitializeComponent();

            // Reduces flickering when the background and PictureBoxes redraw
            this.DoubleBuffered = true;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            this.UpdateStyles();

            // Allows the form to detect key presses even if another control has focus
            this.KeyPreview = true;

            // Saves obstacle images before gameplay starts
            CacheObstacleImages();

            // Starts or restarts the game state
            GameReset();
        }

        private void CacheObstacleImages()
        {
            // Saves the original ground obstacle images
            groundForkImage = pbGroundFork.Image;
            groundKnifeImage = pbGroundKnife.Image;
            groundForkKnifeImage = pbGroundForkKnife.Image;

            // Checks both Image and BackgroundImage for flying obstacles
            flyForkImage = pbFlyFork.Image;

            if (flyForkImage == null)
            {
                flyForkImage = pbFlyFork.BackgroundImage;
            }

            flyKnifeImage = pbFlyKnife.Image;

            if (flyKnifeImage == null)
            {
                flyKnifeImage = pbFlyKnife.BackgroundImage;
            }

            // Keeps ground obstacles aligned with the floor
            groundObstacleTop = 299;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Stops updating gameplay if the game is over
            if (gameOver)
            {
                return;
            }

            // Displays current game information on the screen
            lblScore.Text =
                "Score: " + score +
                " | Mode: " + GameSettings.Difficulty +
                " | Speed: " + obstacleSpeed +
                " | Test Mode: " + (testMode ? "ON" : "OFF");

            // Runs the main game updates every timer tick
            UpdateSceneMode();
            UpdateGameSpeed();
            UpdatePlayerJump();
            UpdateObstacles();
            UpdateCoin();
        }

        private void UpdateSceneMode()
        {
            // Changes from day to night when the score reaches the night score
            if (score >= nightScore && currentScene != "Night")
            {
                currentScene = "Night";
                this.BackgroundImage = Properties.Resources.NightBackground;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            // Changes back to day mode when the game resets
            else if (score < nightScore && currentScene != "Day")
            {
                currentScene = "Day";
                this.BackgroundImage = Properties.Resources.wall4;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void ShowPauseMenu()
        {
            // Stops the timer so the game freezes
            isPaused = true;
            GameTimer.Stop();

            // Shows the pause panel above the game
            pnlPause.Visible = true;
            pnlPause.BringToFront();
        }

        private void HidePauseMenu()
        {
            // Hides the pause panel and continues the timer
            isPaused = false;
            pnlPause.Visible = false;

            GameTimer.Start();
        }

        private void UpdateGameSpeed()
        {
            // Stops this method if the current difficulty does not increase speed over time
            if (!speedIncreasesOverTime)
            {
                return;
            }

            difficultyTimer++;

            // Increases speed at a set rate without going over the maximum speed
            if (difficultyTimer % speedIncreaseRate == 0 && obstacleSpeed < maxObstacleSpeed)
            {
                obstacleSpeed++;

                // Updates all obstacle objects with the new speed
                foreach (Obstacle obstacle in obstacles)
                {
                    obstacle.SetSpeed(obstacleSpeed);
                }

                // Updates the coin speed if the coin object exists
                if (coin != null)
                {
                    coin.SetSpeed(obstacleSpeed);
                }
            }
        }

        private void UpdatePlayerJump()
        {
            if (isJumping)
            {
                // Moves the player vertically
                pbPlayer.Top += verticalSpeed;

                // Applies normal gravity while the player moves upward
                if (verticalSpeed < 0)
                {
                    verticalSpeed += gravity;
                }
                // Applies stronger gravity while the player falls
                else
                {
                    verticalSpeed += fallGravity;
                }

                // Stops the jump when the player reaches the ground
                if (pbPlayer.Top >= groundY)
                {
                    pbPlayer.Top = groundY;
                    isJumping = false;
                    verticalSpeed = 0;
                    jumpsMade = 0;

                    // Ducks immediately after landing if the down key is still held
                    if (downKeyHeld && GameSettings.Difficulty != GameDifficulty.Easy)
                    {
                        Duck();
                    }
                }
            }
        }

        private void UpdateObstacles()
        {
            // Loops through every obstacle in the obstacle list
            for (int i = 0; i < obstacles.Count; i++)
            {
                Obstacle obstacle = obstacles[i];

                // Skips invisible obstacles
                if (!obstacle.Visible)
                {
                    continue;
                }

                // Updates the obstacle through the Obstacle parent type
                obstacle.Update();

                // Ends the game if the player collides with an obstacle and test mode is off
                if (!testMode && PlayerCollidesWith(obstacle))
                {
                    EndGame();
                    return;
                }

                // Adds score when the player successfully passes an obstacle
                if (!obstacle.Counted && obstacle.Right < pbPlayer.Left)
                {
                    score += GetScoreValue();
                    obstacle.Counted = true;
                }

                // Resets the obstacle if it leaves the screen
                ResetObstacleIfNeeded(i);
            }
        }

        private void UpdateCoin()
        {
            // Hides coins outside night mode
            if (currentScene != "Night")
            {
                pbCoin.Visible = false;
                return;
            }

            // Creates the coin object if it has not been created yet
            if (coin == null)
            {
                coin = new Coin(pbCoin, coinValue, obstacleSpeed);
            }

            // Keeps the coin moving at the current game speed
            coin.SetSpeed(obstacleSpeed);

            // Places the coin again if it is hidden
            if (!coin.Active)
            {
                ResetCoin();
            }

            // Moves the coin left
            coin.Update();

            // Resets the coin if it moves off screen
            if (coin.Right < 0)
            {
                ResetCoin();
            }

            // Creates a smaller player hitbox for fair coin collection
            Rectangle playerHitBox = new Rectangle(
                pbPlayer.Left + 8,
                pbPlayer.Top + 6,
                pbPlayer.Width - 16,
                pbPlayer.Height - 12
            );

            // Adds coin points and hides the coin if the player touches it
            if (playerHitBox.IntersectsWith(coin.GetHitBox()))
            {
                score += coin.Value;
                coin.Hide();
            }
        }

        private void ResetCoin()
        {
            // Creates the coin if it does not exist yet
            if (coin == null)
            {
                coin = new Coin(pbCoin, coinValue, obstacleSpeed);
            }

            // Places the coin ahead of the farthest obstacle
            int farthestX = GetFarthestObstacleX();

            int coinLeft = farthestX + random.Next(250, 500);
            int coinTop = random.Next(coinTopMin, coinTopMax + 1);

            coin.ResetPosition(coinLeft, coinTop);
        }

        private int GetScoreValue()
        {
            // Gives more points per obstacle in harder modes
            if (GameSettings.Difficulty == GameDifficulty.Easy)
            {
                return 1;
            }

            if (GameSettings.Difficulty == GameDifficulty.Medium)
            {
                return 2;
            }

            return 3;
        }

        private bool PlayerCollidesWith(Obstacle obstacle)
        {
            Rectangle playerHitBox;

            // Uses a smaller player hitbox while ducking
            if (isDucking)
            {
                playerHitBox = new Rectangle(
                    pbPlayer.Left + 8,
                    pbPlayer.Top + 5,
                    pbPlayer.Width - 16,
                    pbPlayer.Height - 10
                );
            }
            // Uses a normal player hitbox when standing or jumping
            else
            {
                playerHitBox = new Rectangle(
                    pbPlayer.Left + 8,
                    pbPlayer.Top + 6,
                    pbPlayer.Width - 16,
                    pbPlayer.Height - 12
                );
            }

            Rectangle obstacleHitBox;

            // Creates a hitbox for flying obstacles
            if (obstacle is FlyingObstacle)
            {
                obstacleHitBox = new Rectangle(
                    obstacle.Left + 3,
                    obstacle.Top + 3,
                    obstacle.PictureBox.Width - 6,
                    obstacle.PictureBox.Height - 6
                );
            }
            // Creates a hitbox for ground obstacles
            else
            {
                obstacleHitBox = new Rectangle(
                    obstacle.Left + 4,
                    obstacle.Top + 4,
                    obstacle.PictureBox.Width - 8,
                    obstacle.PictureBox.Height - 8
                );
            }

            // Returns true if the player hitbox overlaps the obstacle hitbox
            return playerHitBox.IntersectsWith(obstacleHitBox);
        }

        private void ResetObstacleIfNeeded(int obstacleIndex)
        {
            Obstacle obstacle = obstacles[obstacleIndex];

            // Stops reset if the obstacle has not fully left the screen
            if (obstacle.Left >= -100)
            {
                return;
            }

            // Gets the next position, spacing, and obstacle type
            int farthestX = GetFarthestObstacleX();
            int spacing = GetNextSpacing();
            ObstacleKind nextKind = GetNextObstacleKind();

            SetObstacleKind(obstacleIndex, nextKind, farthestX + spacing, true);
        }

        private int GetNextSpacing()
        {
            // Picks random spacing based on the selected difficulty
            int spacing = random.Next(minSpacing, maxSpacing + 1);

            // Adds a small speed adjustment so spacing reacts to speed
            int speedAdjustment = obstacleSpeed * 3;

            return spacing + speedAdjustment;
        }

        private ObstacleKind GetNextObstacleKind()
        {
            // Gets the next obstacle type from the selected difficulty pattern
            ObstacleKind kind = currentObstaclePattern[currentObstacleIndex];

            currentObstacleIndex++;

            // Restarts the pattern when it reaches the end
            if (currentObstacleIndex >= currentObstaclePattern.Length)
            {
                currentObstacleIndex = 0;
            }

            return kind;
        }

        private int GetFarthestObstacleX()
        {
            int farthestX = 0;

            // Finds the obstacle that is farthest to the right
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.Visible && obstacle.Left > farthestX)
                {
                    farthestX = obstacle.Left;
                }
            }

            return farthestX;
        }

        private void SetObstacleKind(int obstacleIndex, ObstacleKind kind, int leftPosition, bool visible)
        {
            // Reuses an existing PictureBox slot from the obstacle list
            PictureBox slot = obstacles[obstacleIndex].PictureBox;

            slot.BackgroundImage = null;
            slot.SizeMode = PictureBoxSizeMode.Zoom;
            slot.Tag = "obstacle";
            slot.Visible = visible;

            Obstacle newObstacle;

            // Creates a ground fork obstacle
            if (kind == ObstacleKind.GroundFork)
            {
                slot.Image = groundForkImage;
                slot.Size = new Size(28, 64);

                newObstacle = new GroundObstacle(slot, obstacleSpeed, groundObstacleTop);
            }
            // Creates a ground knife obstacle
            else if (kind == ObstacleKind.GroundKnife)
            {
                slot.Image = groundKnifeImage;
                slot.Size = new Size(26, 64);

                newObstacle = new GroundObstacle(slot, obstacleSpeed, groundObstacleTop);
            }
            // Creates a ground fork-knife obstacle
            else if (kind == ObstacleKind.GroundForkKnife)
            {
                slot.Image = groundForkKnifeImage;
                slot.Size = new Size(44, 64);

                newObstacle = new GroundObstacle(slot, obstacleSpeed, groundObstacleTop);
            }
            // Creates a flying fork obstacle
            else if (kind == ObstacleKind.FlyFork)
            {
                slot.Image = flyForkImage;
                slot.Size = new Size(46, 50);

                newObstacle = new FlyingObstacle(slot, obstacleSpeed, flyingObstacleTop);
            }
            // Creates a flying knife obstacle
            else
            {
                slot.Image = flyKnifeImage;
                slot.Size = new Size(48, 50);

                newObstacle = new FlyingObstacle(slot, obstacleSpeed, flyingObstacleTop);
            }

            // Moves the new obstacle into position and resets its state
            newObstacle.ResetPosition(leftPosition);
            newObstacle.Visible = visible;
            newObstacle.Counted = false;
            newObstacle.SetSpeed(obstacleSpeed);

            // Replaces the old obstacle object with the new obstacle object
            obstacles[obstacleIndex] = newObstacle;
        }

        private void EndGame()
        {
            // Stops gameplay and saves the final score
            gameOver = true;
            GameTimer.Stop();

            string playerName = SaveScoreRecord();

            // Gets the best score after saving the current score
            ScoreRecord bestScore = HighScoreManager.GetTopScores(1)[0];

            lblScore.Text =
                "GAME OVER! Score: " + score +
                " | Best: " + bestScore.Score;

            ShowGameOverPanel(playerName, bestScore);
        }

        private void ShowGameOverPanel(string playerName, ScoreRecord bestScore)
        {
            // Fills the custom game over panel with final game information
            lblPlayerName.Text = "Player: " + playerName;
            lblFinalScore.Text = "Score: " + score;
            lblBestScore.Text = "The Best Score: " + bestScore.Score;
            lblGameOverDifficulty.Text = "Difficulty: " + GameSettings.Difficulty;

            pnlGameOver.Visible = true;
            pnlGameOver.BringToFront();

            btnGameOverRestart.Focus();
        }

        private string SaveScoreRecord()
        {
            // Gets the player name and saves the score
            string playerName = AskForPlayerName();

            HighScoreManager.AddScore(playerName, score, GameSettings.Difficulty);

            return playerName;
        }

        private string AskForPlayerName()
        {
            // Creates a small form so the player can enter a name
            Form nameForm = new Form();
            nameForm.Text = "Save Score";
            nameForm.Width = 300;
            nameForm.Height = 160;
            nameForm.StartPosition = FormStartPosition.CenterParent;
            nameForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            nameForm.MaximizeBox = false;
            nameForm.MinimizeBox = false;

            Label lblName = new Label();
            lblName.Text = "Enter your name:";
            lblName.Left = 20;
            lblName.Top = 20;
            lblName.Width = 240;

            TextBox txtName = new TextBox();
            txtName.Left = 20;
            txtName.Top = 50;
            txtName.Width = 240;
            txtName.Text = "Player";

            Button btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Left = 185;
            btnOk.Top = 85;
            btnOk.Width = 75;
            btnOk.DialogResult = DialogResult.OK;

            nameForm.Controls.Add(lblName);
            nameForm.Controls.Add(txtName);
            nameForm.Controls.Add(btnOk);

            // Allows the Enter key to submit the name form
            nameForm.AcceptButton = btnOk;

            nameForm.ShowDialog();

            string playerName = txtName.Text.Trim();

            // Uses a default name if the player leaves the box empty
            if (playerName == "")
            {
                playerName = "Player";
            }

            nameForm.Dispose();

            return playerName;
        }

        private void ShowHighScores()
        {
            // Stops if there are no saved scores
            if (!HighScoreManager.HasScores())
            {
                MessageBox.Show(
                    "No high scores yet.",
                    "High Scores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string message = "All Scores:\n\n";

            // Gets saved scores from the high score manager
            List<ScoreRecord> allScores = HighScoreManager.GetTopScores(100);

            // Builds the high score message line by line
            for (int i = 0; i < allScores.Count; i++)
            {
                message += (i + 1) + ". " + allScores[i].ToString() + "\n";
            }

            MessageBox.Show(
                message,
                "All Scores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ReturnToMenu()
        {
            // Stops the game and closes this form
            GameTimer.Stop();

            if (this.Owner != null && !this.Owner.IsDisposed)
            {
                this.Owner.Show();
            }

            this.Close();
        }

        private void AddCheatScore()
        {
            // Adds points quickly for testing
            score += 10;
        }

        private void ClearObstaclesCheat()
        {
            // Moves all obstacles away from the player for testing
            int startX = this.ClientSize.Width + 250;

            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].Left = startX + (i * 350);
                obstacles[i].Counted = false;
            }
        }

        private void ToggleTestMode()
        {
            // Turns collision immunity on or off
            testMode = !testMode;
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            // Restarts the game after game over
            if (gameOver && e.KeyCode == Keys.Enter)
            {
                GameReset();
                return;
            }

            // Pauses or resumes the game with Spacebar
            if (!gameOver && e.KeyCode == Keys.Space)
            {
                if (isPaused)
                {
                    HidePauseMenu();
                }
                else
                {
                    ShowPauseMenu();
                }

                return;
            }

            // Ignores gameplay controls while paused
            if (isPaused)
            {
                return;
            }

            // Returns to the menu
            if (e.KeyCode == Keys.M)
            {
                ReturnToMenu();
                return;
            }

            // Shows high scores
            if (e.KeyCode == Keys.H)
            {
                ShowHighScores();
                return;
            }

            // Adds score for testing
            if (e.KeyCode == Keys.C)
            {
                AddCheatScore();
                return;
            }

            // Moves obstacles away for testing
            if (e.KeyCode == Keys.B)
            {
                ClearObstaclesCheat();
                return;
            }

            // Toggles test mode
            if (e.KeyCode == Keys.T)
            {
                ToggleTestMode();
                return;
            }

            // Makes the player jump if jump conditions are valid
            if (e.KeyCode == Keys.Up && !isDucking && jumpsMade < maxJumps)
            {
                isJumping = true;
                isDucking = false;

                pbPlayer.Width = normalPlayerWidth;
                pbPlayer.Height = normalPlayerHeight;

                verticalSpeed = jumpPower;
                jumpsMade++;
            }

            // Makes the player duck or fall faster
            // Easy mode does not use ducking
            if (e.KeyCode == Keys.Down && GameSettings.Difficulty != GameDifficulty.Easy)
            {
                downKeyHeld = true;

                if (isJumping)
                {
                    verticalSpeed += 6;
                }
                else
                {
                    Duck();
                }
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            // Stops ducking when the down key is released
            if (e.KeyCode == Keys.Down)
            {
                downKeyHeld = false;
                StopDucking();
            }
        }

        private void Duck()
        {
            // Changes the player size to ducking size
            if (!isJumping && !isDucking)
            {
                isDucking = true;

                pbPlayer.Width = duckPlayerWidth;
                pbPlayer.Height = duckPlayerHeight;
                pbPlayer.Top = duckPlayerTop;
            }
        }

        private void StopDucking()
        {
            // Returns the player to normal size
            if (isDucking)
            {
                isDucking = false;

                pbPlayer.Width = normalPlayerWidth;
                pbPlayer.Height = normalPlayerHeight;
                pbPlayer.Top = groundY;
            }
        }

        private void ApplyDifficultySettings()
        {
            // Resets the obstacle pattern index when difficulty is applied
            currentObstacleIndex = 0;

            if (GameSettings.Difficulty == GameDifficulty.Easy)
            {
                obstacleSpeed = 7;
                maxObstacleSpeed = 13;

                speedIncreasesOverTime = false;
                speedIncreaseRate = 300;

                minSpacing = 580;
                maxSpacing = 720;

                currentObstaclePattern = easyObstaclePattern;
            }
            else if (GameSettings.Difficulty == GameDifficulty.Medium)
            {
                obstacleSpeed = 10;
                maxObstacleSpeed = 19;

                speedIncreasesOverTime = true;
                speedIncreaseRate = 100;

                minSpacing = 380;
                maxSpacing = 500;

                currentObstaclePattern = mediumObstaclePattern;
            }
            else
            {
                obstacleSpeed = 12;
                maxObstacleSpeed = 22;

                speedIncreasesOverTime = true;
                speedIncreaseRate = 55;

                minSpacing = 220;
                maxSpacing = 320;

                currentObstaclePattern = hardObstaclePattern;
            }
        }

        private void CreateObstacleSlots()
        {
            // Clears the obstacle list before adding new obstacle objects
            obstacles.Clear();

            // Adds both ground and flying obstacle objects to the same Obstacle list
            obstacles.Add(new GroundObstacle(pbGroundFork, obstacleSpeed, groundObstacleTop));
            obstacles.Add(new GroundObstacle(pbGroundForkKnife, obstacleSpeed, groundObstacleTop));
            obstacles.Add(new GroundObstacle(pbGroundKnife, obstacleSpeed, groundObstacleTop));
            obstacles.Add(new FlyingObstacle(pbFlyFork, obstacleSpeed, flyingObstacleTop));
            obstacles.Add(new FlyingObstacle(pbFlyKnife, obstacleSpeed, flyingObstacleTop));

            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.PictureBox.Tag = "obstacle";
                obstacle.SetSpeed(obstacleSpeed);
            }
        }

        private void PositionObstaclesAtStart()
        {
            currentObstacleIndex = 0;

            // Places Easy obstacles at starting positions
            if (GameSettings.Difficulty == GameDifficulty.Easy)
            {
                SetObstacleKind(0, GetNextObstacleKind(), 700, true);
                SetObstacleKind(1, GetNextObstacleKind(), 1400, true);
                SetObstacleKind(2, GetNextObstacleKind(), 2100, true);

                SetObstacleKind(3, ObstacleKind.FlyFork, 3000, false);
                SetObstacleKind(4, ObstacleKind.FlyKnife, 3500, false);
            }
            // Places Medium obstacles at closer starting positions
            else if (GameSettings.Difficulty == GameDifficulty.Medium)
            {
                SetObstacleKind(0, GetNextObstacleKind(), 650, true);
                SetObstacleKind(1, GetNextObstacleKind(), 1170, true);
                SetObstacleKind(2, GetNextObstacleKind(), 1630, true);

                SetObstacleKind(3, ObstacleKind.FlyFork, 3000, false);
                SetObstacleKind(4, ObstacleKind.FlyKnife, 3500, false);
            }
            // Places Hard obstacles with both ground and flying obstacles visible
            else
            {
                SetObstacleKind(0, GetNextObstacleKind(), 760, true);
                SetObstacleKind(1, GetNextObstacleKind(), 1060, true);
                SetObstacleKind(2, GetNextObstacleKind(), 1360, true);
                SetObstacleKind(3, GetNextObstacleKind(), 1680, true);
                SetObstacleKind(4, GetNextObstacleKind(), 1980, true);
            }

            // Resets scoring status and speed for all obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Counted = false;
                obstacle.SetSpeed(obstacleSpeed);
            }
        }

        private void GameReset()
        {
            // Applies speed, spacing, and obstacle pattern based on selected difficulty
            ApplyDifficultySettings();

            // Resets background to day mode
            currentScene = "Day";
            this.BackgroundImage = Properties.Resources.wall4;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Resets game state
            score = 0;
            isJumping = false;
            isDucking = false;
            downKeyHeld = false;
            gameOver = false;
            testMode = false;
            isPaused = false;

            // Hides pause and game over panels
            pnlPause.Visible = false;
            pnlGameOver.Visible = false;

            // Resets coin
            pbCoin.Visible = false;
            coin = new Coin(pbCoin, coinValue, obstacleSpeed);

            // Resets movement and difficulty timer
            verticalSpeed = 0;
            jumpsMade = 0;
            difficultyTimer = 0;

            currentObstacleIndex = 0;

            lblScore.Text =
                "Score: " + score +
                " | Mode: " + GameSettings.Difficulty +
                " | Speed: " + obstacleSpeed +
                " | Test Mode: OFF";

            // Uses the selected character if the player chose one
            if (GameSettings.SelectedCharacter != null)
            {
                pbPlayer.Image = GameSettings.SelectedCharacter.RunningImage;
            }
            else
            {
                pbPlayer.Image = Properties.Resources.KhinkaliRunning;
            }

            pbPlayer.SizeMode = PictureBoxSizeMode.Zoom;

            // Resets player position and size
            pbPlayer.Top = groundY;
            pbPlayer.Left = 70;

            pbPlayer.Width = normalPlayerWidth;
            pbPlayer.Height = normalPlayerHeight;

            // Calculates the player position while ducking
            duckPlayerTop = groundY + (normalPlayerHeight - duckPlayerHeight);

            CreateObstacleSlots();
            PositionObstaclesAtStart();

            GameTimer.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ReturnToMenu();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            HidePauseMenu();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            pnlPause.Visible = false;
            isPaused = false;
            GameReset();
        }

        private void pnlPause_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnGameOverRestart_Click(object sender, EventArgs e)
        {
            pnlGameOver.Visible = false;
            GameReset();
        }

        private void btnGameOverScore_Click(object sender, EventArgs e)
        {
            ShowHighScores();
        }

        private void btnGameOverMenu_Click(object sender, EventArgs e)
        {
            ReturnToMenu();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}