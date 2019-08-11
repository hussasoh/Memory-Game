using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memory_Game.Models
{
    public class Player
    {
        /// <summary>
        /// The player's account username
        /// </summary>
        private string _username;

        /// <summary>
        /// The player's score for the current game
        /// </summary>
        private ScoreBackup _score;

        /// <summary>
        /// The player's remaining lives
        /// </summary>
        private int _lives;

        /// <summary>
        /// Ensures the username is not null of empty
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                    throw new Exception(message: "Invalid username");
                else
                    _username = value;
            }
        }

        /// <summary>
        /// Ensures the player's remaining lives will not drop below 0
        /// </summary>
        public int Lives
        {
            get { return _lives; }
            set
            {
                if (value >= 0)
                    _lives = value;
                else
                    throw new Exception(message: "Lives cannot be negative");
            }
        }

        /// <summary>
        /// Creates a new player with a score of 0 (for starting a game)
        /// </summary>
        /// <param name="username">The player's username</param>
        /// <param name="difficulty">The game's starting difficulty</param>
        /// <param name="mode">The game mode</param>
        public Player(string username, Difficulty difficulty, GameMode mode)
        {
            Username = username;
            _score = new ScoreBackup(Username, 0, difficulty, mode);
        }

        // maybe put this somewhere else
        public void Guess()
        {

        }

        /// <summary>
        /// Decrement the player's life count when they lose a round
        /// </summary>
        public void LoseLife()
        {
            Lives--;
            if (Lives < 0)
                GameOver();
        }

        /// <summary>
        /// Increment the score by the amount the player gained this round
        /// </summary>
        /// <param name="score">The amount to increase the score by</param>
        public void GainScore(int score)
        {
            _score.IncreaseScore(score);
        }

        /// <summary>
        /// Handles end of game logic once the player has lost all their lives.
        /// </summary>
        public void GameOver()
        {
            Console.WriteLine("Game over");
        }
    }
}