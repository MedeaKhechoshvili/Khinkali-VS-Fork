namespace Khinkali
{

    // This class keeps track of the selected character and selected difficulty
   
    public static class GameSettings
    {
       
        // Gets or sets the character chosen by the player
        // Form1 uses this to decide which character image to display
        public static PlayableCharacter SelectedCharacter { get; set; }

        // Gets or sets the selected difficulty mode.
        // The default difficulty is Easy if the player does not choose another mode
        public static GameDifficulty Difficulty { get; set; } = GameDifficulty.Easy;
    }
}