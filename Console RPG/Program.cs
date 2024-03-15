using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    class Program
    {
        public static List<string> options = new List<string> { };
        public static string[] romNum = new string[] { "N/A", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
        public static string[] blocks = new string[] { " ", "░", "▒", "▓", "█"};

        static void Main(string[] args)
        {
            Location.locationI.SetNearby(Location.locationII);
            Location.locationII.SetNearby(Location.locationIII, Location.locationIV, Location.locationI, Location.locationXXIV);
            Location.locationIII.SetNearby(Location.locationXXIX, null, Location.locationII);
            Location.locationIV.SetNearby(null, Location.locationV, null, Location.locationII);
            Location.locationV.SetNearby(Location.locationVIII, Location.locationXII, Location.locationVI, Location.locationIV);
            Location.locationVI.SetNearby(Location.locationV, null, Location.locationVII);
            Location.locationVII.SetNearby(Location.locationVI);
            Location.locationVIII.SetNearby(Location.locationIX, null, Location.locationV);
            Location.locationIX.SetNearby(Location.locationX, null, Location.locationVIII);
            Location.locationX.SetNearby(Location.locationXI, null, Location.locationIX);
            Location.locationXI.SetNearby(null, null, Location.locationX);
            Location.locationXII.SetNearby(null, Location.locationXIII, null, Location.locationV);
            Location.locationXIII.SetNearby(Location.locationXIX, null, Location.locationXIV, Location.locationXII);
            Location.locationXIV.SetNearby(Location.locationXIII, null, Location.locationXV);
            Location.locationXV.SetNearby(Location.locationXIV, Location.locationXVIII, Location.locationXVI);
            Location.locationXVI.SetNearby(Location.locationXV, null, Location.locationXVII);
            Location.locationXVII.SetNearby(Location.locationXVI);
            Location.locationXVIII.SetNearby(null, null, null, Location.locationXV);
            Location.locationXIX.SetNearby(Location.locationXXIII, Location.locationXX, Location.locationXIII);
            Location.locationXX.SetNearby(null, Location.locationXXI, null, Location.locationXIX);
            Location.locationXXI.SetNearby(null, null, Location.locationXXII, Location.locationXX);
            Location.locationXXII.SetNearby(Location.locationXXI);
            Location.locationXXIII.SetNearby(null, null, Location.locationXIX);
            Location.locationXXIV.SetNearby(null, Location.locationII, null, Location.locationXXV);
            Location.locationXXV.SetNearby(null, Location.locationXXIV, Location.locationXXVII, Location.locationXXVI);
            Location.locationXXVI.SetNearby(null, Location.locationXXV);
            Location.locationXXVII.SetNearby(Location.locationXXV, null, Location.locationXXVIII);
            Location.locationXXVIII.SetNearby(Location.locationXXVII);
            Location.locationXXIX.SetNearby(Location.locationXXX, null, Location.locationIII);
            Location.locationXXXI.SetNearby(Location.locationI);

            //int totalExp = 0;
            //int totalCoins = 0;
            //for (int i = 0; i < Location.list.Count; i++)
            //{
            //    if (Location.list[i].battles != null)
            //    {
            //        for (int j = 0; j < Location.list[i].battles.Count; j++)
            //        {
            //            for (int k = 0; k < Location.list[i].battles[j].enemies.Count; k++)
            //            {
            //                totalExp += Location.list[i].battles[j].enemies[k].exp;
            //                totalCoins += Location.list[i].battles[j].enemies[k].coins;
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine(totalExp + ", " + totalCoins);
            Console.WriteLine("What do they call \"you\"?");
            Player.player.name = Console.ReadLine();
            Location.locationI.Resolve();
        }

        public static int InputInt(int min, int max)
        {
            string output = "";
            while (!Int32.TryParse(output, out int h))
            {
                output = Console.ReadLine();
            }
            return Math.Max(Math.Min(Int32.Parse(output), max), min);
        }

        public static string InputString(List<string> options, string text, bool fromRoom = false)
        {
            string output = "";
            bool valid = false;
            Console.WriteLine(text);
            while (!valid)
            {
                output = Console.ReadLine().ToUpper();
                if (fromRoom)
                {
                    if (output == Location.secretSequence[Location.seqPlace])
                    {
                        Location.seqPlace++;
                        if (Location.seqPlace == Location.secretSequence.Length)
                        {
                            Location.seqPlace = 0;
                            Location.locationXXXI.Resolve();
                        }
                    }
                    else
                        Location.seqPlace = 0;
                }
                if (options.Contains(output))
                {
                    valid = true;
                }
            }
            return output;
        }

        public static void Write(string text, int pause, bool beep, int pitch = 800)
        {
            Console.WriteLine(text);
            if (beep)
                Console.Beep(pitch, 200);
            if (!Location.whopp)
                System.Threading.Thread.Sleep(pause);
        }

        public static void WriteSlow(string text, int interval, int intervalPer, int pause, bool beep, bool pauseOnPunc = false)
        {
            if (beep)
                Console.Beep();
            for (int l = 0; l < text.Length; l++)
            {
                Console.Write(text[l]);
                if (l % intervalPer == 0)
                {
                    if (!Location.whopp)
                        System.Threading.Thread.Sleep(interval);
                }
                if (pauseOnPunc && (text[l] == '.' || text[l] == '?'))
                {
                    System.Threading.Thread.Sleep(pause);
                    Console.Beep();
                }
            }
            if (!Location.whopp)
                System.Threading.Thread.Sleep(pause);
            Console.WriteLine();
        }

        public static string Bar(int max, int value, int length)
        {
            string output = value + "";
            for (int f = 0; f < length; f++)
            {
                if (f < length * (value / (float)max))
                {
                    output += "▓";
                }
                else
                {
                    output += "░";
                }
            }
            return output + max;
        }

        public static void GetInventory(List<Enemy> targets = null)
        {
            List<Item> itemChoices = new List<Item>();
            int itemNumber = 0;
            for (int i = 0; i < Item.inventoryOrder.Length; i++)
            {
                if (Item.inventoryOrder[i] == null)
                    Console.WriteLine($"- : - {Item.inventoryOrder[i + 1].GetType().Name} - : -");
                else if (Player.player.inventory.Contains(Item.inventoryOrder[i]))
                {
                    if (Item.inventoryOrder[i] == Player.player.weapon || Item.inventoryOrder[i] == Player.player.armor)
                        Console.WriteLine($"EQUIPPED : X{Player.player.inventory.Where(s => s != null && s == Item.inventoryOrder[i]).Count()} {Item.inventoryOrder[i].name}  .  {Item.inventoryOrder[i].description}");
                    else
                        Console.WriteLine($"{itemNumber} : X{Player.player.inventory.Where(s => s != null && s == Item.inventoryOrder[i]).Count()} {Item.inventoryOrder[i].name}  .  {Item.inventoryOrder[i].description}");
                    itemChoices.Add(Item.inventoryOrder[i]);
                    itemNumber++;
                }
            }
            Console.WriteLine();
            Console.WriteLine(itemNumber + " : GET OUT");
            int itemChosen = InputInt(0, itemNumber);
            if (itemChosen != itemNumber)
            {
                itemChoices[itemChosen].Use(Player.player, targets);
                Console.WriteLine();
            }
        }

        public static Item[] InvChooseTwo(List<Enemy> targets = null)
        {
            List<Item> itemChoices = new List<Item>();
            int itemNumber = 0;
            for (int i = 0; i < Item.inventoryOrder.Length; i++)
            {
                if (Item.inventoryOrder[i] == null)
                    Console.WriteLine($"- : - {Item.inventoryOrder[i + 1].GetType().Name} - : -");
                else if (Player.player.inventory.Contains(Item.inventoryOrder[i]) && Item.inventoryOrder[i].value != 0 && Item.inventoryOrder[i].value != 6)
                {
                    Console.WriteLine($"{itemNumber} : X{Player.player.inventory.Where(s => s != null && s == Item.inventoryOrder[i]).Count()} {Item.inventoryOrder[i].name} v[{Program.romNum[Item.inventoryOrder[i].value]}]");
                    itemChoices.Add(Item.inventoryOrder[i]);
                    itemNumber++;
                }
            }
            Console.WriteLine();
            return new Item[] { itemChoices[InputInt(0, itemNumber - 1)], itemChoices[InputInt(0, itemNumber - 1)] };
        }

        public static void ShowInventory()
        {
            for (int i = 0; i < Item.inventoryOrder.Length; i++)
            {
                if (Player.player.inventory.Contains(Item.inventoryOrder[i]) && Item.inventoryOrder[i] != null)
                {
                    Console.WriteLine($"X{Player.player.inventory.Where(s => s != null && s == Item.inventoryOrder[i]).Count()} {Item.inventoryOrder[i].name}");
                }
            }
            Console.WriteLine();
        }

        public static void EquipCheck()
        {
            if (!Player.player.inventory.Contains(Player.player.weapon))
                Player.player.weapon = Item.weaponI;
            if (!Player.player.inventory.Contains(Player.player.armor))
                Player.player.armor = Item.armorI;
        }


        public static string Garble(int length)
        {
            string output = "";
            Random rand = new Random();
            for (int c = 0; c < length; c++)
            {
                output += blocks[rand.Next(0, 5)];
            }
            return output;
        }
    }
}
