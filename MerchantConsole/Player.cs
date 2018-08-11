using System.Collections.Generic;

namespace MerchantConsole
{
    class Player
    {
        public int Gold { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Gold = 0;
            Inventory = new List<Item>();
        }
    }
}
