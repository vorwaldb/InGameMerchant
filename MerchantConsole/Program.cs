using System;
using System.Linq;

namespace MerchantConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Player {Gold = 15000};

            VisitMerchant(player);
        }

        private static void VisitMerchant(Player player)
        {
            var shop = new Shop();
            var menu = new MenuHandler();
            var merchantAction = MerchantAction.Buy;

            while (merchantAction != MerchantAction.Exit)
            {
                merchantAction = menu.GetMerchantAction(player.Gold);

                switch (merchantAction)
                {
                    case MerchantAction.Buy:
                        PerformBuyingOption(shop, player);
                        break;
                    case MerchantAction.Sell:
                        if (!player.Inventory.Any())
                        {
                            Console.WriteLine("I am sorry, but it looks like you have nothing to sell.");
                            continue;
                        }
                        PerformSellback(player);
                        break;
                    case MerchantAction.Exit:
                        Console.WriteLine("Thank you for your business! Let's shop again sometime! Press any key to exit.");
                        Console.ReadKey();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void PerformBuyingOption(Shop shop, Player player)
        {
            var menuHandler = new MenuHandler();
            var buyingResult = menuHandler.GetItemToBuy(shop.GetAllItems());
            
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

        private static void PerformSellback(Player player)
        {
            var menuHandler = new MenuHandler();
            var sellBackResult = menuHandler.GetItemToSell(player.Inventory);

            if (sellBackResult.IsExitingMenu)
                return;
            
            player.Gold += sellBackResult.ChosenItem.GetTradeInValue();

            player.Inventory.Remove(sellBackResult.ChosenItem);
            Console.WriteLine($"You have sold your {sellBackResult.ChosenItem.Name} for {sellBackResult.ChosenItem.GetTradeInValue()}.");
        }
    }
}
