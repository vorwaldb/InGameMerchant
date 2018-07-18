using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantConsole
{
    class Item
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public ItemType Type { get; private set; }
        public int Price { get; private set; }

        public Item(string name, ItemType type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public bool CanAffordItem(int moneyOnHand)
        {
            return moneyOnHand >= Price;
        }

        public int GetTradeInValue()
        {
            //Trade-in value is 1/3 of  original price
            return Price / 3;
        }
    }
}
