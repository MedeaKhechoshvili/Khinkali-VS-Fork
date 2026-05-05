using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Khinkali
{
    // Form that lets the player choose which khinkali character to use
    // The selected character is saved in GameSettings so Form1 can use it
    public partial class CharacterSelection : Form
    {
        // Stores the playable characters that the player can choose from
        private List<PlayableCharacter> characters;

        public CharacterSelection()
        {
            InitializeComponent();

            // Loads the character options when the form opens
            LoadCharacters();
        }

        private void LoadCharacters()
        {
            // Creates the list of playable character objects
            characters = new List<PlayableCharacter>
            {
                new PlayableCharacter(
                    "Mtiuluri",
                    Properties.Resources.Mtiuluri,
                    Properties.Resources.Mtiulurigif1
                ),

                new PlayableCharacter(
                    "Qalaquri",
                    Properties.Resources.Qalaquri,
                    Properties.Resources.Qalaqurigif
                )
            };

            // Displays the selection images in the picture boxes
            pictureBox1.Image = characters[0].SelectionImage;
            pictureBox2.Image = characters[1].SelectionImage;

            // Makes the images fit nicely inside the picture boxes
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void SelectCharacter(int index)
        {
            // Saves the selected character so Form1 can use it later
            GameSettings.SelectedCharacter = characters[index];

            MessageBox.Show(
                characters[index].Name + " selected!",
                "Character Selected"
            );

            // Closes the character selection form after a choice is made
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Selects the first character in the list
            SelectCharacter(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Selects the second character in the list
            SelectCharacter(1);
        }
    }
}