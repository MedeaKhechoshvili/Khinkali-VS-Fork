using System;
using System.Windows.Forms;

namespace Khinkali
{
    // Form that lets the player choose the game difficulty
    // The selected difficulty is saved in GameSettings so Form1 can use it
    public partial class DifficultySelection : Form
    {
        public DifficultySelection()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            // Save Easy as the selected difficulty
            GameSettings.Difficulty = GameDifficulty.Easy;

            MessageBox.Show(
                "Difficulty set to Easy.",
                "Difficulty",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            // Save Medium as the selected difficulty
            GameSettings.Difficulty = GameDifficulty.Medium;

            MessageBox.Show(
                "Difficulty set to Medium.",
                "Difficulty",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            // Save Hard as the selected difficulty
            GameSettings.Difficulty = GameDifficulty.Hard;

            MessageBox.Show(
                "Difficulty set to Hard.",
                "Difficulty",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }
    }
}