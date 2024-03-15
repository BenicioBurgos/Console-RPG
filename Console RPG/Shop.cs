using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Shop
    {
        public static Shop gasStation = new Shop(new List<Item>() { Item.map, Item.foodII, Item.foodIII, Item.foodIV, Item.foodV, Item.foodVI, Item.foodVII, Item.foodVIII, Item.foodIX, Item.healthPotionI, Item.healthPotionII, Item.healthPotionIII, Item.bombI, Item.weaponIII, Item.weaponIV, Item.armorIII, Item.armorIV }, new List<int>() { 1, -1, -1, -1, -1, -1, -1, 3, 1, -1, -1, -1, 5, 1, 1, 1, 1 });
        public static Shop theBack = new Shop(new List<Item>() { Item.ladder, Item.foodX, Item.healthPotionIII, Item.healthPotionIV, Item.healthPotionV, Item.damagePotionI, Item.bombII, Item.weaponV, Item.armorV }, new List<int>() { 1, 1, 15, 3, 1, -1, 2, 1, 1 });

        public List<Item> items;
        public List<int> stock;

        public Shop(List<Item> items, List<int> stock)
        {
            this.items = items;
            this.stock = stock;
        }

        public void Resolve(ConsoleColor color)
        {
            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.WriteLine("BALANCE" + Player.player.coins);
                for (int i = 0; i < items.Count; i++)
                {
                    if (stock[i] == 0)
                        Console.ForegroundColor = ConsoleColor.Black;
                    else if (items[i].price <= Player.player.coins)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i} == {items[i].name} : {items[i].description}  ({items[i].price}coin)..{StockText(stock[i])}");
                }
                Console.ForegroundColor = color;
                Console.WriteLine($"{items.Count} == GET OUTGETOUTGOUE TG");
                int choice = Program.InputInt(0, items.Count);
                Console.WriteLine();
                if (choice == items.Count)
                    shopping = false;
                else if (stock[choice] != 0 && items[choice].price <= Player.player.coins)
                {
                    Player.player.coins -= items[choice].price;
                    Player.player.inventory.Add(items[choice]);
                    Console.WriteLine("purchace successful.");
                    if (stock[choice] > 0)
                        stock[choice]--;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("balance = TOO POOR, TRY BETTER");
                    Console.ReadLine();
                }
            }
        }

        public string StockText(int stock)
        {
            if (stock == 0)
                return "][OUT-0F-ST0CK][";
            else if (stock > 0)
                return "][" + stock + "-LEFT][";
            else
                return "";
        }
    }
}
