namespace MerchantConsole
{
    /// <summary>
    /// Class containing information relating to the result of a merchant action
    /// </summary>
    public class MenuResult
    {
        /// <summary>
        /// Whether or not the user elected to leave the menu altogether
        /// </summary>
        public bool IsExitingMenu { get; set; }
        
        /// <summary>
        /// The item the user chose to buy or sell
        /// </summary>
        public Item ChosenItem { get; set; }
    }
}