using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memory_Game.Models
{
    /// <summary>
    /// An entire memory game that starts when the user chooses a difficulty and game mode,
    /// and ends when the user loses all their lives
    /// </summary>
    public class MemoryGame
    {
        /// <summary>
        /// The game's starting difficulty.
        /// </summary>
        private Difficulty _difficulty;

        /// <summary>
        /// The game mode (type of MemoryItems that will appear)
        /// </summary>
        private GameMode _gameMode;

        /// <summary>
        /// The current round number
        /// </summary>
        private int _round;

        /// <summary>
        /// The player of this game
        /// </summary>
        private Player _player;

        /// <summary>
        /// The speed and score multipliers for each starting difficulty
        /// </summary>
        private readonly float[] diffMultiplier = {1.0f, 1.5f, 2.0f, 2.5f};

        /// <summary>
        /// Instantiates a new memory game with a game mode, player, and difficulty.
        /// </summary>
        public MemoryGame()
        {

        }

        public void StartGame()
        {

        }

        public void PlayRound()
        {

        }

        public void GameOver()
        {

        }

        private void StorePlayerScore(int score)
        {

        }
    }
}