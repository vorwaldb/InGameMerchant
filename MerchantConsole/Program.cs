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
            var menuAction = MenuAction.Buy;

            while (menuAction != MenuAction.Exit)
            {
                menuAction = menu.GetMenuAction(player.Gold);

                switch (menuAction)
                {
                    case MenuAction.Buy:
                        PerformBuyingOption(shop, player);
                        break;
                    case MenuAction.Sell:
                        if (!player.Inventory.Any())
                        {
                            Console.WriteLine("I am sorry, but it looks like you have nothing to sell.");
                            continue;
                        }
                        PerformSellback(player);
                        break;
                    case MenuAction.Exit:
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
            var itemToBuy = menuHandler.GetItemToBuy(shop.GetAllItems());
            
            if (itemToBuy.IsExitingMenu)
                return;
            
            if(itemToBuy.ChosenItem.Price > player.Gold)
            {
                Console.WriteLine("You cannot buy this! You do not have enough gold! Try something else.");
                return;
            }

            player.Inventory.Add(itemToBuy.ChosenItem);
            player.Gold -= itemToBuy.ChosenItem.Price;
            Console.WriteLine($"Congratulations! You have bought a brand new {itemToBuy.ChosenItem.Name}!");
        }

        private static void PerformSellback(Player player)
        {
            var menuHandler = new MenuHandler();
            var sellBackItem = menuHandler.GetItemToSell(player.Inventory);

            if (sellBackItem.IsExitingMenu)
                return;
            
            player.Gold += sellBackItem.ChosenItem.GetTradeInValue();

            player.Inventory.Remove(sellBackItem.ChosenItem);
            Console.WriteLine($"You have sold your {sellBackItem.ChosenItem.Name} for {sellBackItem.ChosenItem.GetTradeInValue()}.");
        }
    }
}
