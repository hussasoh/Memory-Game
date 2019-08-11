using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memory_Game.Models
{
    /// <summary>
    /// Represents a player's score when playing a specific game mode with a 
    /// specific starting difficulty.
    /// </summary>
    public class ScoreBackup
    {
        /// <summary>
        /// The player's name who got this score.
        /// </summary>
        private string _name;

        /// <summary>
        /// The score value
        /// </summary>
        private int _scoreValue;

        /// <summary>
        /// The player's starting difficulty for the game where they got this score
        /// </summary>
        private Difficulty _difficulty;

        private GameMode _gameMode;

        /// <summary>
        /// Ensures the name is not null or empty
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    throw new Exception(message:"Player name cannot be empty");
            }
        }

        /// <summary>
        /// Prevents the score from being negative
        /// </summary>
        public int ScoreValue
        {
            get { return _scoreValue; }
            set
            {
                if (value >= 0)
                    _scoreValue = value;
                else
                    throw new Exception(message: "Score cannot be negative.");
            }
        }

        /// <summary>
        /// Ensures value for _difficulty is valid
        /// </summary>
        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set
            {
                if (value >= 0 && (int)value <= 3)
                    _difficulty = value;
                else
                    throw new Exception(message: "Invalid difficulty");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GameMode GameMode
        {
            get { return _gameMode; }
            set
            {
                if (value >= 0 && (int)value <= 2)
                    _gameMode = value;
                else
                    throw new Exception(message: "Invalid game mode");
            }
        }

        /// <summary>
        /// Creates an object representing that player's score at the starting difficulty level
        /// </summary>
        /// <param name="name">The player's username</param>
        /// <param name="score">The score value</param>
        /// <param name="difficulty">The player's starting difficulty</param>
        public ScoreBackup(string name, int score, Difficulty difficulty, GameMode gameMode)
        {
            Name = name;
            ScoreValue = score;
            Difficulty = difficulty;
            GameMode = gameMode;
        }

        /// <summary>
        /// Add to the player's score
        /// </summary>
        /// <param name="scoreInc">The amount to increment the score by.</param>
        public void IncreaseScore(int scoreInc)
        {
            if (scoreInc >= 0)
                ScoreValue += scoreInc;
            else
                throw new Exception(message: "Cannot add negative values to the score.");
        }
    }
}