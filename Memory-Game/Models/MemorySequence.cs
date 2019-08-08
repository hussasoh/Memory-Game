using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memory_Game.Models
{
    public struct MemorySequence
    {
        public List<MemoryItem> Sequence;
        public float SpeedMultiplier;

        /// <summary>
        /// Create a list of randomly generated memory items
        /// </summary>
        /// <param name="length">The length of the sequence</param>
        /// <param name="speed">How quickly the items will appear to the user</param>
        /// <param name="mode">The game mode (determines type of MemoryItem generated)</param>
        public MemorySequence(int length, float speed, GameMode mode)
        {
            Sequence = new List<MemoryItem>();
            for (int i = 0; i < length; i++)
            {
                // randomly generate and add memory items
                switch(mode)
                {
                    case GameMode.NUMBERS:
                        Sequence.Add(new MemoryNumber());
                        break;
                    case GameMode.LETTERS:
                        break;
                    case GameMode.SHAPES:
                        break;
                }
            }
            SpeedMultiplier = speed;
        }
    }
}