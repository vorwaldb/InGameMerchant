using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
