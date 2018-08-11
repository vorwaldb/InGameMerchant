using System;
using System.Linq;

namespace MerchantConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Player {Gold = 15000};
            var shop = new Shop();
            var menuHandler = new MenuHandler();

            VisitMerchant(player, shop, menuHandler);
        }

        private static void VisitMerchant(Player player, Shop shop, MenuHandler menuHandler)
        {
            //Initializing to "Buy" so that menu does not exit right away
            var merchantAction = MerchantAction.Buy;

            while (merchantAction != MerchantAction.Exit)
            {
                merchantAction = menuHandler.GetMerchantAction(player.Gold);

                switch (merchantAction)
                {
                    case MerchantAction.Buy:
                        PerformBuyingOption(shop, player, menuHandler);
                        break;
                    case MerchantAction.Sell:
                        if (!player.Inventory.Any())
                        {
                            Console.WriteLine("I am sorry, but it looks like you have nothing to sell.");
                            continue;
                        }
                        PerformSellback(player, menuHandler);
                        break;
                    case MerchantAction.Exit:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            Console.WriteLine("Thank you for your business! Let's shop again sometime! Press any key to exit.");
            Console.ReadKey();
        }

        private static void PerformBuyingOption(Shop shop, Player player, MenuHandler menuHandler)
        {
            var shopItems = shop.GetAllItems();
            var buyingResult = menuHandler.GetItemToBuy(shopItems);
            
            if (buyingResult.IsExitingMenu)
                return;
            
            if(buyingResult.ChosenItem.Price > player.Gold)
            {
                Console.WriteLine("You cannot buy this! You do not have enough gold! Try something else.");
                return;
            }

            player.Inventory.Add(buyingResult.ChosenItem);
            player.Gold -= buyingResult.ChosenItem.Price;
            Console.WriteLine($"Congratulations! You have bought a brand new {buyingResult.ChosenItem.Name}!");
        }

        private static void PerformSellback(Player player, MenuHandler menuHandler)
        {
            var sellBackResult = menuHandler.GetItemToSell(player.Inventory);

            if (sellBackResult.IsExitingMenu)
                return;
            
            player.Gold += sellBackResult.ChosenItem.GetTradeInValue();

            player.Inventory.Remove(sellBackResult.ChosenItem);
            Console.WriteLine($"You have sold your {sellBackResult.ChosenItem.Name} for {sellBackResult.ChosenItem.GetTradeInValue()}.");
        }
    }
}
