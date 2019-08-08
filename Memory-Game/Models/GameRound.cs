using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memory_Game.Models
{
    /// <summary>
    /// Contains the logic for a single round of the game. One sequence of memory items 
    /// appears and the player tries to repeat them in the same order. They lose life if 
    /// they guess wrong and gain score if they guess right.
    /// </summary>
    public class GameRound
    {
        /// <summary>
        /// The sequence of items to memorize this round.
        /// </summary>
        private MemorySequence _sequence;

        public GameRound()
        {

        }

    }
}