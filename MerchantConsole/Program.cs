using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantConsole
{
    class Program
    {
        private const int Buy = 1;
        private const int Sell = 2;
        private const int Exit = 3;

        private 

        static void Main(string[] args)
        {
            var player = new Player();
            player.Gold = 15000;

            VisitMerchant(player);
        }

        static void VisitMerchant(Player player)
        {
            var shop = new Shop();
            var menuSelection = 0;

            while (menuSelection != 3)
            {
                DisplayMenu(player.Gold);
                var enteredText = Console.ReadLine().Trim();

                if (!IsValidMenuSelection(enteredText, 1, 3))
                {
                    Console.WriteLine("Please attempt your selection again");
                    continue;
                }

                menuSelection = int.Parse(enteredText);

                if (menuSelection == Buy)
                {
                    PerformBuyingOption(shop, player);
                }
                else if (menuSelection == Sell)
                {
                    if(!player.Inventory.Any())
                    {
                        Console.WriteLine("I am sorry, but it looks like you have nothing to sell.");
                        continue;
                    }

                    PerformSellback(player);
                }
                else
                {
                    Console.WriteLine("Thank you for your business! Let's shop again sometime! Press any key to exit.");
                    Console.ReadKey();
                }
            }
        }

        static void PerformBuyingOption(Shop shop, Player player)
        {
            var itemsOnSale = shop.GetAllItems();
            var maxItemNumber = itemsOnSale.Count();
            var backMenu = maxItemNumber + 1;

            var buyingText = "Please choose an item to buy:";

            var itemDictionary = new Dictionary<int, Item>();

            for (var num = 0; num < maxItemNumber; num++)
            {
                var item = itemsOnSale[num];
                var itemNumber = num + 1;

                itemDictionary.Add(itemNumber, item);

                buyingText += $"{Environment.NewLine}{itemNumber} - {item.Name} - Price: {item.Price}";
            }

            buyingText += $"{Environment.NewLine}{backMenu} - Back{Environment.NewLine}";

            Console.WriteLine(buyingText);
            var answer = Console.ReadLine();

            while (!IsValidMenuSelection(answer, 1, backMenu))
            {
                Console.WriteLine("That is not a valid item choice. Please try again.");
                Console.WriteLine(buyingText);
                answer = Console.ReadLine();
            }

            var selectedAnswer = int.Parse(answer);
            if (selectedAnswer == backMenu)
                return;

            var itemToBuy = itemDictionary[selectedAnswer];

            if(itemToBuy.Price > player.Gold)
            {
                Console.WriteLine("You cannot buy this! You do not have enough gold! Try something else.");
                return;
            }

            player.Inventory.Add(itemToBuy);
            player.Gold -= itemToBuy.Price;
            Console.WriteLine($"Congratulations! You have bought a brand new {itemToBuy.Name}!");
        }

        static void PerformSellback(Player player)
        {
            var maxItemNumber = player.Inventory.Count();
            var backMenu = maxItemNumber + 1;

            var sellingText = "Please choose an item to sell:";

            var itemDictionary = new Dictionary<int, Item>();
            
            for(var num = 0; num < maxItemNumber; num++)
            {
                var item = player.Inventory[num];
                var itemNumber = num + 1;

                itemDictionary.Add(itemNumber, item);

                sellingText += $"{Environment.NewLine}{itemNumber} - {item.Name} - Trade-Back: {item.GetTradeInValue()}";
            }

            sellingText += $"{Environment.NewLine}{backMenu} - Back{Environment.NewLine}"; 

            Console.WriteLine(sellingText);
            var answer = Console.ReadLine();

            while(!IsValidMenuSelection(answer, 1, backMenu))
            {
                Console.WriteLine("That is not a valid item choice. Please try again.");
                Console.WriteLine(sellingText);
                answer = Console.ReadLine();
            }

            var selectedAnswer = int.Parse(answer);
            if (selectedAnswer == backMenu)
                return;

            var sellBackItem = itemDictionary[selectedAnswer];
            player.Gold += sellBackItem.GetTradeInValue();

            player.Inventory.Remove(sellBackItem);
            Console.WriteLine($"You have sold your {sellBackItem.Name} for {sellBackItem.GetTradeInValue()}.");
        }

        static void DisplayMenu(int currentGold)
        {

            var menuText = $"Welcome to the Travelling Merchant! Have we got good deals for you!{Environment.NewLine}What would you like to do?";
            menuText += $"{Environment.NewLine}{Buy} - Buy{Environment.NewLine}{Sell} - Sell{Environment.NewLine}{Exit} - Exit";

            var goldText = $"{Environment.NewLine}Current Gold: {currentGold}{Environment.NewLine}";

            var builder = new StringBuilder();
            var dashes = builder.Append('-', goldText.Trim().Length + 2).ToString();

            Console.WriteLine($"{dashes}{goldText}{dashes}");
            Console.WriteLine(menuText);
            Console.WriteLine();
        }

        static bool IsValidMenuSelection(string enteredText, int minChoice, int maxChoice)
        {
            var numberList = new List<int>();

            for(var num = minChoice; num <= maxChoice; num++)
            {
                numberList.Add(num);
            }

            if(int.TryParse(enteredText, out var number))
            {
                if (numberList.Contains(number))
                    return true;

                Console.WriteLine("Error: Invalid Menu Selection");
            }
            else
            {
                Console.WriteLine("Error: Invalid Input");
            }

            return false;
        }
    }
}
