using System;
using System.Collections.Generic;
using System.IO;

namespace Khinkali
{
    // Manages the game's high score records
    // Stores scores in a list and saves them to a text file
    public static class HighScoreManager
    {
        // Stores all score records while the program is running
        private static List<ScoreRecord> scoreRecords = new List<ScoreRecord>();

        // Stores the relative file path for the high score file
        private static string filePath = "highscores.txt";

        public static void AddScore(string playerName, int score, GameDifficulty difficulty)
        {
            // Loads existing scores before adding the new score
            LoadScores();

            // Creates a new score record from the completed game
            ScoreRecord record = new ScoreRecord(
                playerName,
                score,
                difficulty
            );

            // Adds the new score record to the list
            scoreRecords.Add(record);

            // Sorts the score list using ScoreRecord.CompareTo
            scoreRecords.Sort();

            // Removes extra scores if the list has more than 10 records
            if (scoreRecords.Count > 10)
            {
                scoreRecords.RemoveRange(10, scoreRecords.Count - 10);
            }

            // Saves the updated score list to the text file
            SaveScores();
        }

        public static List<ScoreRecord> GetTopScores(int amount)
        {
            // Loads saved scores from the text file
            LoadScores();

            // Sorts the score list so the best scores appear first
            scoreRecords.Sort();

            int count = amount;

            // Uses the actual number of scores if fewer scores exist than requested
            if (scoreRecords.Count < amount)
            {
                count = scoreRecords.Count;
            }

            // Returns the requested top section of the sorted score list
            return scoreRecords.GetRange(0, count);
        }

        public static bool HasScores()
        {
            // Loads saved scores before checking the list
            LoadScores();

            // Returns true if at least one score exists
            return scoreRecords.Count > 0;
        }

        private static void SaveScores()
        {
            // Opens the high score file for writing
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (ScoreRecord record in scoreRecords)
                {
                    // Writes one score record per line using | as a separator
                    writer.WriteLine(
                        record.PlayerName + "|" +
                        record.Score + "|" +
                        record.Difficulty + "|" +
                        record.DatePlayed
                    );
                }
            }
        }

        private static void LoadScores()
        {
            // Clears the current list so loaded scores are not duplicated
            scoreRecords.Clear();

            // Stops loading if the high score file does not exist yet
            if (!File.Exists(filePath))
            {
                return;
            }

            // Reads all lines from the high score file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Splits each line into player name, score, difficulty, and date
                string[] parts = line.Split('|');

                if (parts.Length == 4)
                {
                    string playerName = parts[0];

                    // Converts the saved score text into an integer
                    int score;
                    bool scoreIsValid = int.TryParse(parts[1], out score);

                    // Converts the saved difficulty text into a GameDifficulty value
                    GameDifficulty difficulty;
                    bool difficultyIsValid = Enum.TryParse(parts[2], out difficulty);

                    // Converts the saved date text into a DateTime value
                    DateTime datePlayed;
                    bool dateIsValid = DateTime.TryParse(parts[3], out datePlayed);

                    // Adds the record only if all converted values are valid
                    if (scoreIsValid && difficultyIsValid && dateIsValid)
                    {
                        ScoreRecord record = new ScoreRecord(
                            playerName,
                            score,
                            difficulty
                        );

                        // Restores the original saved date for the score record
                        record.DatePlayed = datePlayed;

                        // Adds the loaded score record to the list
                        scoreRecords.Add(record);
                    }
                }
            }
        }
    }
}