using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Khinkali
{
    // Main menu form for the game
    // Lets the player start the game, read instructions, choose character, choose difficulty, view scores, or exit
    public partial class Menu : Form
    {
        public Menu()
        {
            // Loads the menu controls from the Designer
            InitializeComponent();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            // Hides the menu while the game form is open
            this.Hide();

            // Creates and opens the main game form
            Form1 game = new Form1();
            game.ShowDialog();

            // Shows the menu again after the game form closes
            this.Show();
        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            // Displays the controls, rules, and cheat keys
            MessageBox.Show(
                "How to Play:\n\n" +
                "Press UP ARROW to jump.\n" +
                "Press DOWN ARROW to duck or fall faster.\n" +
                "Press SPACEBAR to pause or resume the game.\n" +
                "Avoid forks and knives.\n" +
                "Coins appear during night mode and give bonus points.\n" +
                "Night mode starts when the score reaches 50.\n" +
                "Press ENTER to restart after Game Over.\n" +
                "Press M to return to the menu.\n" +
                "Press H to view all saved scores.\n\n" +
                "Testing / Cheat Keys:\n" +
                "Press C to add 10 points.\n" +
                "Press B to move obstacles away.\n" +
                "Press T to toggle test mode/invincibility.",
                "Instructions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void charactersbtn_Click(object sender, EventArgs e)
        {
            // Opens the character selection form
            CharacterSelection characterSelection = new CharacterSelection();
            characterSelection.ShowDialog();
        }

        private void Scorebtn_Click(object sender, EventArgs e)
        {
            // Checks whether any scores exist before displaying them
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

            string message = "Top 3 High Scores:\n\n";

            // Gets the top three saved scores
            List<ScoreRecord> topScores = HighScoreManager.GetTopScores(3);

            // Builds the high score message line by line
            for (int i = 0; i < topScores.Count; i++)
            {
                message += (i + 1) + ". " + topScores[i].ToString() + "\n";
            }

            // Shows the high score message
            MessageBox.Show(
                message,
                "High Scores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Settingsbtn_Click(object sender, EventArgs e)
        {
            // Opens the difficulty selection form
            DifficultySelection difficultyForm = new DifficultySelection();
            difficultyForm.ShowDialog();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            // Closes the whole application
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // This event is currently not used
        }
    }
}