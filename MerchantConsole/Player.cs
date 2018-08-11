using System.Collections.Generic;

namespace MerchantConsole
{
    /// <summary>
    /// Class defining the player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Amount of gold the player has
        /// </summary>
        public int Gold { get; set; }
        
        /// <summary>
        /// The items the player has in their inventory
        /// </summary>
        public List<Item> Inventory { get; }

        /// <summary>
        /// Creates a new instance of the Player class
        /// </summary>
        public Player()
        {
            Gold = 0;
            Inventory = new List<Item>();
        }
    }
}
