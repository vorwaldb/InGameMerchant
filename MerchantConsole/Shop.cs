﻿using System.Collections.Generic;

namespace MerchantConsole
{
    /// <summary>
    /// Class containing functionality related to the shop
    /// </summary>
    public class Shop
    {
        private List<Item> _weaponInventory;
        private List<Item> _armorInventory;
        private List<Item> _potionInventory;

        /// <summary>
        /// Creates a new instance of the Shop class
        /// </summary>
        public Shop()
        {
            PopulateWeapons();
            PopulateArmor();
            PopulatePotions();
        }

        /// <summary>
        /// Returns a list of all items available in the shop
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItems()
        {
            var items = new List<Item>();
            items.AddRange(_potionInventory);
            items.AddRange(_weaponInventory);
            items.AddRange(_armorInventory);

            return items;
        }

        private void PopulatePotions()
        {
            _potionInventory = new List<Item>
            {
                new Item("Red Potion", 200)
            };
        }

        private void PopulateArmor()
        {
            _armorInventory = new List<Item>()
            {
                new Item("Shield of Red Dwarfs", 1000),
                new Item("Wooden Shield", 100),
                new Item("Chainmail", 400)
            };
        }

        private void PopulateWeapons()
        {
            _weaponInventory = new List<Item>()
            {
                new Item("Fire Sword", 300),
                new Item("Dead Man Axe", 800),
                new Item("Golden Bow", 550),
                new Item("Staff of the Violet Wizard", 600)
            };
        }
    }
}