using System.Drawing;

namespace Khinkali
{
    // Represents a character that the player can choose before starting the game
    // Stores the character name, selection image, and running image
    public class PlayableCharacter
    {
        // Stores the character's display name
        // private set means it can only be changed inside this class
        public string Name { get; private set; }

        // Stores the image shown on the character selection screen
        public Image SelectionImage { get; private set; }

        // Stores the image used for the player during the main game
        public Image RunningImage { get; private set; }

        public PlayableCharacter(string name, Image selectionImage, Image runningImage)
        {
            // Sets the character name
            Name = name;

            // Sets the image used on the character selection screen
            SelectionImage = selectionImage;

            // Sets the image used during gameplay
            RunningImage = runningImage;
        }
    }
}