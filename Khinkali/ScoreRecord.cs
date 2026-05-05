using System;

namespace Khinkali
{
    
    // Implements IComparable so score records can be sorted from best to lowest
    public class ScoreRecord : IComparable<ScoreRecord>, IComparable
    {
        // Stores the name entered by the player
        public string PlayerName { get; set; }

        // Stores the final score earned by the player
        public int Score { get; set; }

        // Stores the difficulty mode used during the game
        public GameDifficulty Difficulty { get; set; }

        // Stores the date and time when the score was created
        public DateTime DatePlayed { get; set; }

        public ScoreRecord(string playerName, int score, GameDifficulty difficulty)
        {
            // Sets the player name for this score record
            PlayerName = playerName;

            // Sets the final score for this score record
            Score = score;

            // Sets the difficulty used for this score record
            Difficulty = difficulty;

            // Saves the current date and time when the record is created
            DatePlayed = DateTime.Now;
        }

        public int CompareTo(ScoreRecord other)
        {
            // Handles a null comparison object so the program does not crash
            if (other == null)
            {
                return 1;
            }

            // Compares scores in reverse order so higher scores appear first
            int scoreComparison = other.Score.CompareTo(this.Score);

            // Returns the score comparison if the scores are different
            if (scoreComparison != 0)
            {
                return scoreComparison;
            }

            // Compares difficulty if the scores are equal
            // Harder difficulty appears first
            int difficultyComparison = other.Difficulty.CompareTo(this.Difficulty);

            // Returns the difficulty comparison if the difficulties are different
            if (difficultyComparison != 0)
            {
                return difficultyComparison;
            }

            // Compares dates if score and difficulty are equal
            // Newer scores appear first
            return other.DatePlayed.CompareTo(this.DatePlayed);
        }

        public int CompareTo(object obj)
        {
            // Converts the general object into a ScoreRecord if possible
            ScoreRecord other = obj as ScoreRecord;

            // Handles invalid or null objects so the program does not crash
            if (other == null)
            {
                return 1;
            }

            // Reuses the main ScoreRecord comparison method
            return CompareTo(other);
        }

        public override string ToString()
        {
            // Formats the score record for display in the high score list
            return PlayerName +
                   " | Score: " + Score +
                   " | Difficulty: " + Difficulty +
                   " | " + DatePlayed.ToShortDateString() +
                   " " + DatePlayed.ToShortTimeString();
        }
    }
}