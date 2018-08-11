namespace MerchantConsole
{
    /// <summary>
    /// Defines an item that can be bought and sold from a merchant
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// A short description of the item
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The type of the item
        /// </summary>
        public ItemType Type { get; }
        
        /// <summary>
        /// The price for which one pays to buy the item
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Creates a new instance of the Item class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="price"></param>
        public Item(string name, ItemType type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        /// <summary>
        /// Gets the amount the merchant will pay for an item when selling it
        /// </summary>
        public int GetTradeInValue()
        {
            //Trade-in value is 1/3 of  original price
            return Price / 3;
        }
    }
}
