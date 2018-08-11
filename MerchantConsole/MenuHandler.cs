﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantConsole
{
    public class MenuHandler
    {
        public MenuAction GetMenuAction(int currentGold)
        {
            const int buyAction = (int)MenuAction.Buy;
            const int sellAction = (int)MenuAction.Sell;
            const int exitAction = (int)MenuAction.Exit;
            
            var selectionText = $"{Environment.NewLine}{buyAction} - Buy{Environment.NewLine}{sellAction} - Sell{Environment.NewLine}{exitAction} - Exit";
            
            var menuText = $"Welcome to the Travelling Merchant! Have we got good deals for you!{Environment.NewLine}What would you like to do?";
            menuText += selectionText;

            var goldText = $"{Environment.NewLine}Current Gold: {currentGold}{Environment.NewLine}";

            var builder = new StringBuilder();
            var dashes = builder.Append('-', goldText.Trim().Length + 2).ToString();

            Console.WriteLine($"{dashes}{goldText}{dashes}");
            Console.WriteLine(menuText);
            Console.WriteLine();
            
            var enteredText = Console.ReadLine()?.Trim();

            while (!IsValidMenuSelection(enteredText, 1, 3))
            {
                Console.WriteLine("Please attempt your selection again.");
                Console.WriteLine(selectionText);
                enteredText = Console.ReadLine()?.Trim();
            }

            // ReSharper disable once AssignNullToNotNullAttribute
            var menuActionString = int.Parse(enteredText);
            return (MenuAction) menuActionString;
        }

        public MenuResult GetItemToSell(List<Item> itemsToSell)
        {
            return GetMenuReturnItemForAction(MenuAction.Sell, itemsToSell);
        }

        public MenuResult GetItemToBuy(List<Item> itemsToBuy)
        {
            return GetMenuReturnItemForAction(MenuAction.Buy, itemsToBuy);
        }

        private MenuResult GetMenuReturnItemForAction(MenuAction actionToPerform, List<Item> menuItems)
        {
            var maxItemNumber = menuItems.Count;
            var backMenu = maxItemNumber + 1;

            var textOption = actionToPerform == MenuAction.Buy ? "buy" : "sell";
            var displayText = $"Please choose an item to {textOption}:";
            
            var itemDictionary = new Dictionary<int, Item>();

            for (var num = 0; num < maxItemNumber; num++)
            {
                var item = menuItems[num];
                var itemNumber = num + 1;

                itemDictionary.Add(itemNumber, item);
                var itemAmount = actionToPerform == MenuAction.Buy ? item.Price : item.GetTradeInValue();
                displayText += $"{Environment.NewLine}{itemNumber} - {item.Name} - Price: {itemAmount}";
            }

            displayText += $"{Environment.NewLine}{backMenu} - Back{Environment.NewLine}";
            
            Console.WriteLine(displayText);
            var answer = Console.ReadLine();
            
            while (!IsValidMenuSelection(answer, 1, backMenu))
            {
                Console.WriteLine("That is not a valid item choice. Please try again.");
                Console.WriteLine(displayText);
                answer = Console.ReadLine();
            }
            
            // ReSharper disable once AssignNullToNotNullAttribute
            var selectedAnswer = int.Parse(answer);
            if (selectedAnswer == backMenu)
                return new MenuResult{ChosenItem = null, IsExitingMenu = true};

            var pickedItem = itemDictionary[selectedAnswer];
            return new MenuResult {ChosenItem = pickedItem, IsExitingMenu = false};
        }
        
        private bool IsValidMenuSelection(string enteredText, int minChoice, int maxChoice)
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