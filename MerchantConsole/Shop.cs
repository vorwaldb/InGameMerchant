using System.Collections.Generic;

namespace MerchantConsole
{
    class Shop
    {
        private List<Item> weaponInventory;
        private List<Item> armorInventory;
        private List<Item> potionInventory;
        private List<Item> toolInventory;

        public Shop()
        {
            PopulateWeapons();
            PopulateArmor();
            PopulatePotions();

            toolInventory = new List<Item>();
        }

        public List<Item> GetAllItems()
        {
            var items = new List<Item>();
            items.AddRange(potionInventory);
            items.AddRange(weaponInventory);
            items.AddRange(armorInventory);
            items.AddRange(toolInventory);

            return items;
        }

        public List<Item> GetItemsForType(ItemType type)
        {
            switch (type)
            {
                case ItemType.Potion:
                    return potionInventory;
                case ItemType.Weapon:
                    return weaponInventory;
                case ItemType.Armor:
                    return armorInventory;
                case ItemType.Tool:
                    return toolInventory;
            }

            return new List<Item>();
        }

            private void PopulatePotions()
        {
            potionInventory = new List<Item>
            {
                new Item("Red Potion", ItemType.Potion, 200){Description =  "A potion strong enough to heal even the greatest of injuries, the only downfall is that it won't mend severed limbs."}
            };
        }

        private void PopulateArmor()
        {
            armorInventory = new List<Item>()
            {
                new Item("Shield of Red Dwarfs", ItemType.Armor, 1000){Description = "A powerful shield said to have defended an entire clan from dragons, this will stop almost anything."},
                new Item("Wooden Shield", ItemType.Armor, 100){Description = "A basic shield for beginners, you will want to keep this thing away from fire."},
                new Item("Chainmail", ItemType.Armor, 400){Description = "This full body set of chainmail will make it tougher for even the strongest blades to pierce your innards."},
            };
        }

        private void PopulateWeapons()
        {
            weaponInventory = new List<Item>()
            {
                new Item("Fire Sword", ItemType.Weapon, 300){Description = "A powerful sword that with magic, can melt even the strongest shields."},
                new Item("Dead Man Axe", ItemType.Weapon, 800){Description = "An axe said to have belonged to the Grim Reaper himself! It has the ability to cut down the undead."},
                new Item("Golden Bow", ItemType.Weapon, 550){Description = "A bow taken straight from the kingdom of elves, this strong bow can down enemies from miles away."},
                new Item("Staff of the Violet Wizard", ItemType.Weapon, 600){Description = "This staff grants its user abnormal phsycial strength, and the ability to dispell powerful magic."}
            };
        }
    }
}