using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public static Item whopper = new KeyItem("whopper", "whopper", 1);
        public static Item map = new KeyItem("Sattelite", "the vision", 12);
        public static Item honeyEsscence = new KeyItem("Honey Esscence", "viscous", 1000);
        public static Item antiForceField = new KeyItem("Force Field Blocker", "illegal in most countries", 6666);
        public static Item machineRigger = new KeyItem("((machine rigger))", "dont tell them", 7777);
        public static Item key = new KeyItem("??KEY??", "KEY???KEY???doordKEY?", 7777777);
        public static Item hugeFortune = new KeyItem("$HUGE$FORTUNE$", "$$$$$$$$$$$$$$$$$", 999999999);
        public static Item ladder = new KeyItem("Ladder", "go^UpgoU^pg^oUpgo^Up^", 2000);
        public static Item allKnowledge = new KeyItem(")ALL()KNOWLEDGE(", "ALL IS KNOWN", 314159265, 9);
        public static Item infinityObject = new KeyItem("the infinity object", "[NO DESCRIPTION FOUND]", 2147483647, 10);

        public static Item healthPotionI = new HealthItem("potion B", "s 10% of:HP", 50, 1, 10);
        public static Item healthPotionII = new HealthItem("potion V1.0", "20%", 150, 2, 20);
        public static Item healthPotionIII = new HealthItem("potion update!", "37%37%37%", 300, 3, 37);
        public static Item healthPotionIV = new HealthItem("potion0.5", "milestone", 750, 4, 50);
        public static Item healthPotionV = new HealthItem("potionALL", "ALL has been:RESTORED", 10000, 6, 100);

        public static Item foodI = new FoodItem("Sand", "this 'food' wwill 5", 10, 1, 5);
        public static Item foodII = new FoodItem("Bubba", "quantity of bubba can 10", 20, 1, 10);
        public static Item foodIII = new FoodItem("Factoid", "A slight truth to 25", 50, 2, 25);
        public static Item foodIV = new FoodItem("Humanoid figure", "this figure 53", 100, 2, 53);
        public static Item foodV = new FoodItem("popcicle", "70 tasty .", 200, 3, 70);
        public static Item foodVI = new FoodItem("Danger", "DANGEROUS ACTIVITY (100)", 500, 3, 100);
        public static Item foodVII = new FoodItem("Tough choice", "WillPrevail!Decide:123", 1000, 4, 123);
        public static Item foodVIII = new FoodItem("Heat Conversion", "h=>246h", 2500, 5, 246);
        public static Item foodIX = new FoodItem("Century", "the time ticks by, 1,000", 5000, 6, 1000);
        public static Item foodX = new FoodItem("ascenfruit", "9a9s9c9e9n9d9", 123456789, 9, 9);
        public static Item foodB = new FoodItem("H.ney", "bloup^50", 99, 2, 50);

        public static Item damagePotionI = new DamageItem("potionPAIN", "poison. 25", 200, 25, 3);
        public static Item damagePotionII = new DamageItem("paition 2", "new50pain", 500, 50, 4);
        public static Item damagePotionIII = new DamageItem("DAMAGE", "100", 2500, 100, 5);
        public static Item tungsten = new DamageItem("|| tungsten ||", "the weight of:75:soldiers", 1000, 75, 5);
        public static Item bombI = new DamageItem("<>gunpowder<>", "10powder 10 pow!der10", 200, 10 , 3, true);
        public static Item bombII = new DamageItem("[]BomB[]", "25 BOOM {25}", 750, 25, 4, true);
        public static Item bombIII = new DamageItem("{}NUKE{}", "66 !HELP!ME! !!!666666)!)", 5000, 66, 6, true);

        public static WeaponItem weaponI = new WeaponItem("finger", "finger(1)", 1, 0, 1);
        public static WeaponItem weaponII = new WeaponItem("PAINstick", "stick(OUCH!)OUCH 3!", 150, 3, 3);
        public static WeaponItem weaponIII = new WeaponItem("Ham", "mer! [thump!] this 5", 300, 4, 5);
        public static WeaponItem weaponIV = new WeaponItem("vladev", "sharp@10.com", 1000, 5, 10);
        public static WeaponItem weaponV = new WeaponItem("SwordOfConvenience", "15)", 3300, 6, 15);
        public static WeaponItem weaponVI = new WeaponItem("SWORD.OF.THE.BEES", "31 bees! HELP,", 100000, 7, 31);

        public static ArmorItem armorI = new ArmorItem("skin...", "skin :)1", 1, 0, 1);
        public static ArmorItem armorII = new ArmorItem("funny hat", "haha, 2!", 100, 2, 2);
        public static ArmorItem armorIII = new ArmorItem("Attire", "!handsome; 4", 250, 3, 4);
        public static ArmorItem armorIV = new ArmorItem("Cloak of sorts?", "mystery??8?...", 1000, 5, 8);
        public static ArmorItem armorV = new ArmorItem("the one of protections", "do you16see me>??", 3300, 6, 16);
        public static ArmorItem armorVI = new ArmorItem("Tungsten}{Cloak", "wow32wow", 100000, 7, 32);

        public static Item[] inventoryOrder = new Item[] { null, whopper, map, honeyEsscence, antiForceField, machineRigger, key, hugeFortune, ladder, allKnowledge, infinityObject, null, healthPotionI, healthPotionII, healthPotionIII, healthPotionIV, healthPotionV, null, foodI, foodII, foodIII, foodB, foodIV, foodV, foodVI, foodVII, foodVIII, foodIX, foodX, null, damagePotionI, damagePotionII, damagePotionIII, tungsten, bombI, bombII, bombIII, null, weaponI, weaponII, weaponIII, weaponIV, weaponV, weaponVI, null, armorI, armorII, armorIII, armorIV, armorV, armorVI };

        public string name;
        public string description;
        public int price;
        public int value;

        public Item(string name, string description, int price, int value = 0)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.value = value;
        }

        public abstract void Use(Entity user, List<Enemy> targets);
    }

    class KeyItem : Item
    {
        public KeyItem(string name, string description, int price, int value = 0) : base(name, description, price, value) { }

        public override void Use(Entity user, List<Enemy> targets)
        {
            if (Battle.finalBoss && this == whopper)
            {//secret boss
                Location.whopp = false;
                Program.WriteSlow("You... used it?", 50, 1, 1000, true, true);
                Program.WriteSlow("Why would you", 100, 1, 0, true);
                for (int i = 0; i < 50; i++)
                {
                    Console.Write(Program.Garble(1000));
                    Console.Beep(100, 50);
                }
                Console.Clear();
            }
            else if (Location.activeKey != this)
                Console.WriteLine(user.name + " you Can't");
            else
            {
                Player.player.inventory.Remove(this);
                if (Location.lockedRoom == Location.locationXXII)
                {//unlock domain
                    Location.locationXXI.description = "unknown forces cannot stop you anymore";
                    Location.locationXXII.locked = false;
                    Location.locationXXI.Resolve();
                }
                else if (Location.lockedRoom == Location.locationXI)
                {//unlock office
                    Location.locationX.visited = false;
                    Location.locationX.image = "████████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████e███████████████████████████████████████▓▓█▓▓▓▓▓███▓▓▓▓▓████████▓▓███████████████████████████████████e█████████████████████████████████████▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓███████▓████████████████████████████████e████████████████████████████████▒░▓████████▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓████▓▓▓▓▓▓████████████████████████e████████████████████████████████▓▒▒▒░░░▓████████████████████████▓▓▒▓▓▓▓█▓███████████████████████████e████████████████████████████████▓▓▓█▓▓▒░    █░▒▒▒░░░░░░░░░░▒▒░▓█▓██▓▓▓▓▓▓▓▓▓▓▓█████▓████████████▓███e█████████████████████████████▓███▓▓▓▓▓▓▓▓▒░ █                 ██▓▓█████████▓██▓▓▓▓███▓██████████████e███████████████████████████▓▓█▓█▓▒▓▓▓▓▓▒░░░ █                 ██▓▓▓▓▓▓▓▓▓▓▓▓█████▓████████████▓█████e█████████████████▓████████████▓█▓▒▓▓▓▓▓▒▒▒░ █                 ██▓▓█████████████████████████████████▓e██████████████▓█▓▓▓▓▓▓▓▓▓▓▓▓▓█▓█▓▒▓▓▒▓▒▒▒▒░ █                 ██▓▓▓▓▓▓▓█▓▓▓▓▓▓▓██▓██▓███████████████e██████████████████████▓█▓█▓▓▓▓▓█▓▒▓▓▒▓▓▒▒▒░ █                 ██▓▓▓▓▓▓▓▓▓▓█████████▓█▓▓████████████▓e███████████████▓▓▓▓▓▓█████▓▓▓▓▓█▓▒▓▓▓▒▓▒▒▒░ █                 ██▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓██████████████████▓e██████████████▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒▒▓▓▓▓▒▒░░ █                 ██▓▓▓▓▓▓▓█▓▓▓█████▓▓▓██████▓█████████▓e███████████████████▓▓▓█▓▓▓█▓█▓▓██▒▒▓▓▓▓▒▒▒░ █                 ██▓█▓▓▓▓▓▓▓▓▓▓█▓▓▓▓██████████████████▓e█████████████▓██▓███▓▓▓▓█▓███▓██▓▒▓▓▓▓▓▒▒▒░ █                 █████▓▓▓▓▓▓██▓▓▓▓█████▓▓▓▓███████████▓e████████████████████▓█████▓▓▓███▓▒▓▓▓▓▓▒▒░░ █                 ██▓▓▓▓██████▓▓▓██▓▓███▓▓█████████████▓e██████████████████▓█▓▓▓▓▓▓▓▓▓▓▓██▒▒▓▓▓▓▒▒░░ █                 ███▓▓▓▓▓▓▓▓██▓▓▓█████████████▓▓██████▓e██████████████████▓████▓▓▓▒▒▓▓▓█▓█▓▓▓▒▒▒░░░ █                 ██▓▓▓█▓▓▓▓▓▓▓▓▓█▓▓▓█▓████████████████▓e██████████████████▓█▓█▓▓▓▓██▓███▓▒▓▓▓█▓▓▒░░ █                 █████▓▓▓█████▓▓▓▓▓▓▓▓▓██▓██▓█████████▓e███████████████████▓▓█▓██▓▓▓▓▓▓██▒▓▓▓▓▒▒▒░░ █                 ██▓▓▓▓██▓▓▓▓████████▓▓▓█████▓████████▓e█████████████████████▓▓██▓██████▓▒▒█▒▓▓▒▒░░ █                 ███▓▓▓▓████▓▓▓█▓▓▓████▓▓▓▓▓█▓████████▓e███████████████████████▓▓█▓▓█▓▓██▒▒█▒▓▓▒▒░░ █                 ██▓▓█▓▓█▓▓▓▓▓▓██▓▓▓█▓▓▓██████████████▓e████████████████████▓██▓███▓██▓█▓▒▓█▓▓▓▒▒▒░ █                 ██▓▓▓▓▓█▓▓▓▓██▓▓▓█████▓▓▓██▓█████████▓e█████████████████████████▓▓▓▓▓▓██▒▒▓▒▓▓▒░░░ █                 ██▓▓███▓▓▓▓▓▓████████▓███▓█▓██████████e████████████████████▓▓█▓▓▓▓█▓█▓██▒▒▓▓█▓▓▒▒░░█                 ██▓▓▓▓▓▓████▓█▓▓██▓█▓▓█████▓█████████▓e████████████████████████▓▓▓███▓█▓▒▓▓▓██████▓█                 █████████▓▓██████▓██████▓████████▓▓██▓e█████████████████████████▓█▓▓▓▓███████▒                           ██████▓▓▓▓▓▓█▓▓▓▓▓██▓█████████████e██████████████████████▓██████████▒                                   ░██████████████████████████▓███e███████████████████████████░       ░░░░░░░░░░░░░░░░░░░░ ░░░░░░░░░░        ██████████████████████████e██████████████████████▒      ░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░    ▒██████████████████████e████████████████▒     ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒    ▒██████████████████e███████████▒    ░▒▓████▓▓▓▓▓▓██▓█▓█▓▓█▒▓▓███▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓██▓▓▓▓▓█▓▒  ░▓██████████████e█████▓░░░░▒▓███████████████████████▓██▒█▓██████████████▓▓███▓█████████████▓██████████▓▒░▒▓██████████e▒▒▒▒▓▓████████████████████████████████▒█▓▓▓▓████▓▓▓▓█████▓▓▓▓▓▓▓█▓▓▓▓▓█▓▓████████████████▓▓▒▓▓██████".Replace("e", Environment.NewLine);
                    Location.locationXI.locked = false;
                    Location.locationX.Resolve();
                }
                else if (Location.lockedRoom == Location.locationVII)
                {//unlock back
                    Location.locationVII.locked = false;
                    Location.locationVI.Resolve();
                }
                else if (Location.lockedRoom == Location.locationXVII)
                {//unlock library
                    Location.locationXVI.visited = false;
                    Location.locationXVI.description = "It is no longer. Too. High.";
                    Location.locationXVI.image = "██▓▓▓█▓▓▓▓▓█▓▓▓▓▓███▓▓▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓█▓▓▓▓▓▓█▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓█▓▓▓▓▓▓█▓▓▓▓▓███▓▓█▓▓▓▓▓e█▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓██▓e████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓█▓██▓▓███▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓█▓▓█▓▓█▓▓███▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓e██████████▓▒▒██▓▓▓█▓█▓░▓███▓█████████████████▓▓████▓█████████████████▓▓██████████▓▓█████▓███████████e█▓▓▓▓▓▓▓▓▓▓▒▒▓█▓▓█▓▓▓▓░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓██████e██████████▓▒▓████████▓░▓████████████████████████████████████████████████▓▓▓▓████████████████████████e██████████▒░▒▒▒▒▒▒▒▒▒▒▒▓█▓█▓▓▓▓▓█▓▓▓▓▓██████▓▓▓▓▓████████▓▓████▓▓▓▓██▓▓▓▓▓█████▓█▓▓█▓███████▓▓██████e███▓▓█▒▒▒▒▒░▓█▓▓▓█▓▓▓▓░▒▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓█▓██e▓▓▓█▓▓▓▓▓█▒░▓▓▓▓▓▓▓▓▓█░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓e█▓▓▓▓▓▓▒▒▓▒░▓▓▓▓▓▓▒▒▒▒░▒▓▓▓▓▓▓▓▓▓▓▓█▒▓▓▓▒▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▒▒▒▒▒▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓e▓▓▓▓▒▒▒▓▓█▒░▓▓▓▓▓▓▓▓▓▓░▒▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▒▒▒▒▒▓▒▒▓▓▓▓▓▓▒▒▓▓▓▒▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓e█████▓████▒░██▓▓▓▓▓▓▓▓░▒▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓e█▓▓█▓▓▓▓▓█▒▒████▓▓▓▓▓█▒▒▓▓▓▓▓▓▓▓█▓▓▓▓▓█▒▒▒▓▒▓▒▒▒▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓e█▓▓▓▓▒▓▓▓█▒▓██████▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██e██████████░░▒▒▒▒░░▒▒▒░░▒█████████████████████████▓██████████████████████████████████████████████████e██▓████▓██░▓██████████▒▒██▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▒▒▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓█████e███▓▓▓████░▓██████▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▒▓▓▓▓▓▒▒▒▓█▓▓▒▓▒▒▒▒▒▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓█▓▓▓▓▓█████e██████████▒▓████▓▓▓▓██▒▒▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓███▓████▓▓▓██████████e██▓▓▓█▓▓█▓░░░░░░░░░░░░▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▒▒▒▓▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓e█▓█▓▓▓▓██▓░▓███▓▓▓▓▓█▓▒░▒▒▓▒▒▒▒▒▓▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▒▒▓▓▒▒▒▒▒▓▒▓▓▓▓▓▓▓▓▓█▓▓▓▓▓███e█████████▒░████▓▓█▓▓▓▓▒░▓▓▓▓▓▓▒▒▒▒▒▓▓▓▒▒▓▓▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓e███▓▓████▒▒█████▓▓▓▓█▓▒░▓▓▓▒▒▒▒▒▓▒▒▒▒▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓████e██▓▓▓████▒░░░░░░░░▒░░░░░▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▒▓▓▓▓▓▒▒▒▒▒▓▒▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓▓██████e█████████░▒███████████▒░▓██▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓█▓▓▓▓▓██████████████████████████e█████████░▒███████████▓░▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████e█████████░▒███████████▓░▓█████████████████████▓█████▓▓▓▓████████████████████████████████████████████e█████████░░░░▒▒▒░░░░░▒░░▓█████████████████▓███▓█████▓████████▓█▓████████████████████████████████████e█████████░▓███████████▓▒▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓████████▓███e█████████░▓███████████▓░▓████▓█▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓██▓▓▓▓▓█▓▓▓▓████▓▓█████▓█████████████████████e█████████░▓███████████▓░▒█▓▓▓▓▓▓▓▓▓▓███▓▓█▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█████████████████████████████e█████████░▒▓▓▓▓▓▒▒▒▒▒▓▒░▒███▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓██▓▓▓▓██▓▓█████████████████e████████▓░▓████████████▒▒█████▓███▓█▓▓▓▓▓▓▓▓▓▓▓▓▓█████▓▓▓▓▓█▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓██▓▓███████████████████e████████▓▒▓████████████▒▒██████▓█▓▓▓▓▓█▓▓▓▓▓█▓▓▓▓▓███████▓▓▓▓▓█▓▓▓▓█████████████████████████████████e████████▓▒▓████████████▒▒███████▓▓▓█▓▓▓▓▓█▓▒▒▒▒▓▓▓▓▓▓█▓▓▓▓▓██▓▓▓█████▓████████▓▓▓▓▓█████████████████e████████▓▒█████████████▒▒███████████████████████████████████████████████████████████████████████████e████████▓░░░░░░░░░░░░░▒▒▒███████████████████▓▓█████▓▓███████████████████████████████████████████████e████████▓▓█████████████▓▒███████████████████████████████████████████████████████████████████████████e█████████▓█████████████▓▒███████████████████████████████████████████████████████████████████████████".Replace("e", Environment.NewLine);
                    Location.locationXVII.locked = false;
                    Location.locationXVI.Resolve();
                }
                else if (Location.lockedRoom == Location.locationXXIX)
                {//unlock infinity
                    Location.locationIII.visited = false;
                    Location.locationIII.name = "EXIT";
                    Location.locationIII.description = "It's time.";
                    Location.locationIII.image = "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░       ░░ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░e░▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓▒▓▒▒▒▒▒▒▒▓███     █▓▓▓▒▓▓▒▓▒▓▒▓▓▒▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓░e░▓▓▓▓▓▓▒▓▓▓▒▓▓▓▓▒▓▓▒▒▒▒▒▒▒▓▒▒▒▒▓▓▒▓▒▒▓▓▓▓▓▓█░  ░░░  ▒█▓▓▒▒▒▒▒▒▒▓▓▒▒▒▒▒▓▒▒▒▒▓▒▒▓▓▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▓▓▓░e░▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▒▒▓▒▓▓▒▒▓▓█▓    ░░ ░   ▓█▓▓▓▒▒▓▒▓▓▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▒▓▒▓▓▒▓▒▓▓▒▒▒▓▓██░   ░░░░░░░   ░██▓▓▒▓▒▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▒▒▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▒▓▓▓▓██░    ░░░░░░ ░░    ░██▓▓▒▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▒▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓█▒░    ░░ ░░ ▒ ░░░░ ░ ░▒█▓▓▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▒▓▓▓▓▒▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▒▓▓▓▓▓▓▓▒▓▓▓▓█▓░ ░ ░ ▒░░░ ░ ▒░░░░░░  ░ ░▓█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓░░░▒ ░ ░▒░░▒ ▒░▒░ ▒░░░░░░▒░░░▓█▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓░░░░░░░  ▒░░ ░ ▒ ░▒ ░▒░▒░░░ ▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▒▒▓▓▓▓▓▓█▒░░░▒░░░░ ▒░▒░░░ ▒░░▒░░░░░░░░░░▒░ ░░▒▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓█▓░░░░▒░░░░ ▒▒░░░░░░▒░▒▒░ ▒░░░▒░░░░░▒░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒░░░░▒░░░░ ▒▒░░░░▒░░▒░░▒░░░▒▒░▒░░░░░░▓░░▒░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░▒▒░░▒░ ░▒░░░░░▓░░▒░▒▒░░░▒░░░▒░░░░░░▒░░░▒░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▒░░░░░▒▒░░▒░ ░▒▒░▒ ░░▒░░▒░░▒▒░░░░▒ ▒▒░░░░░░▒▒░░▒▒░▒▓█▓▓▒▒▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░▒░▒▒░░░▒░░ ▒▒░░░░░▒░░░▒░░▒▒▒░░▓░▒░▒▒░░░░░░▒▓░░░▒░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓█▓▒▒░░▒░▒▒░░▒▒░░░▒▒▒░░░░░▒░░▒▒░░▒▒▒░░▒░▒░░▒░░░░░░░░▓▒░░▒▒▒▒▒▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒░▒▒░▒▒░░▒▒░░ ▒▒▒░▒░░░░▒░░░░░░▒▒▒░░░▒░▒░▒▒▒░░░░▒░░▓▒░░▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▒▒▒░▒▒▒░▓▒░░▒▒▒░░▒▒▒░░░░▒░▒▒ ░▒▒░░▒░▒▒░░▒░▒▒░▒▒▒░░░░░░░▒▓░░▒▒▒▒░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒░▒▒▒░▒▒░░░▒▒░░ ░▒▒▒░▒░░▒░▓░░░▒▒░░▒▒▒░░░░▒░▒░░▒▒▒░▒▒░▒▒░▒▓░░░▒▒░▒▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▒░▒▓░░░▒▒░▒░░▒▒▓░▒▒░▒░░▓░░░▒░░░▒▒▒▒▒░░▓░▒▒ ▒▒▒░░░░░▒▒░▒▓▒░░░▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒░░▒▒░░░▒▒░░░░▒▒▒░░▒░░░░▒▒░░░▒▒░░▒▒▒▒▒░░▒▓░▓░░▒▒▒▒░▒░░▒▒░░▓▓░░▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒░▒▒▒░░░▒▒░░░░▒▒▒▒░▒▒░▒░░▒▒░▒░▒░░░▒░▒▒▒░░░▓░▒▓░░▒▒▒░░▒▒░▒▒░░▓▓▒░▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▓▒▒░░░▒▒░░░░▒▓▒▓░░▒░░▒░░▓░░░░▒░░░▒░▒▒▒▒░░▒▒░▓▒░▒▒▒▒░▒▒▒▒▒▒░░▒▓▒░░▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓░e░▓▓▓▓▓▒▒▒▒▒▒▒▒░▒▒▒▒░░▒▒▒░▒░░░▓▒▓▒░▒▒░▒░░▒▒░░▒░▓▒░░▒▒▒▒▒▒░░░▓░░▓░░▒▒░▒░░░▒▒░▒░░▒▓▓░░░▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓░e░▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░▒▒░▒░░░▓▒▒▒░▒▒░░▒░░▒▒░░░▒▒░░░▒▒▒▒▒▒░░░▒▒░▒▒░░▒▒▒▒░▒▒░▒░▒▒░░▓▓▒░░▒▒▒▒▒▒▒▒▒▒▓▓▓▓░e░▓▒▒▒▒▒▒▒▒▒▒░▒▒▒░░░▒▓▒░▒▒░░▓▒▒▓░░▒▒░▒▒░░▓▒░░░▒▓▒▒░▒▒▒▒▒░▒░░▒▓░░▓▒░▒▒▒▒▒▒▒▒▒▒░▒▒░░▓▓▒░░▒▒▒▒▒▒▒▒▒▓▒▓▓░e░▓▒▒▒▒▒▒▓▒░▒▒▒▒░▒▒▒▒▒░▒▒░░▒▒▒▓▒░▒▒░▒▒░░▒▓▒░▒░▒▓░░░▒▒▒▒▒▒▒░░░▒▒░▒▓░░▒▒▒▒▒░▒▒▒▒▒▒▒░░▒▓▓░░▒▒▒▒▒▒▒▒▓▒▒▓░e░▒▒▒▒▒▒▒▒▒▓▒▒▒░░▒▒▓▒▒▒▒░░▒▓▒▒▓░░▒░░▒▒░░▒▒░░▒░▒▓░░░▒▒▒▒▒▒▒░░░▒▓░░▓▒░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▓▓▒░░▒▒▒▒▒▒▒▒▒▒░e░▒▒▒▒▓▒░▒▓▒▒▒░▒▒▒▓▒░▒▒░░▒▓▒▒▓░░▒▒░░▒▒░░▓▒░░▒░▒▓░░░░▒▒▒▒▒▒▒░░░▓▒░▓▓░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▓▓▒░░▒▒▒▒▒▒▒▒▒░".Replace("e", Environment.NewLine);
                    Location.locationXXIX.locked = false;
                    Location.locationIII.Resolve();
                }
            }
        }
    }

    class HealthItem : Item
    {
        public int percentage;

        public HealthItem(string name, string description, int price, int value, int percentage) : base(name, description, price, value)
        {
            this.percentage = percentage;
        }

        public override void Use(Entity user, List<Enemy> targets)
        {
            Player.player.inventory.Remove(this);
            user.hp = Math.Min(user.hp + user.stats.maxHP / 100 * percentage, user.stats.maxHP);
            Console.WriteLine(user.name + " iNCREMENT " + percentage + "% !");
        }
    }

    class FoodItem : Item
    {
        public int health;

        public FoodItem(string name, string description, int price, int value, int health) : base(name, description, price, value)
        {
            this.health = health;
        }

        public override void Use(Entity user, List<Enemy> targets)
        {
            if (name != "ascenfruit")
            {
                Player.player.inventory.Remove(this);
                if (Location.activeKey == this && Location.lockedRoom == Location.locationXXVIII)
                {//unlock comb
                    Location.locationXXVII.description = "he is \"pleased\"";
                    Location.locationXXVIII.locked = false;
                    Location.locationXXVII.Resolve();
                }
                user.hp = Math.Min(user.hp + health, user.stats.maxHP);
                Console.WriteLine(user.name + " up " + health + " AMOUNT");
            }
            else
            {
                Console.WriteLine("I wouldn't do that if I were you.");
            }
        }
    }

    class DamageItem : Item
    {
        public int damage;
        public bool splash;

        public DamageItem(string name, string description, int price, int damage, int value, bool splash = false) : base(name, description, price, value)
        {
            this.damage = damage;
            this.splash = splash;
        }

        public override void Use(Entity user, List<Enemy> targets)
        {
            if (targets != null)
            {
                Player.player.inventory.Remove(this);
                if (splash)
                {
                    foreach (Enemy enemy in targets)
                        enemy.hp -= damage;
                    Console.WriteLine("<ALL> down " + damage + " AMOUNT");
                }
                else
                {
                    Entity target = user.ChooseTarget(targets);
                    target.hp -= damage;
                    Console.WriteLine(target.name + " down " + damage + " AMOUNT");
                }
            }
            else
                Console.WriteLine(user.name + " you Can't");
        }
    }

    class WeaponItem : Item
    {
        public int damage;

        public WeaponItem(string name, string description, int price, int value, int damage) : base(name, description, price, value)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, List<Enemy> target)
        {
            user.weapon = this;
            Program.Write("you are using. it. now", 0, true);
        }
    }

    class ArmorItem : Item
    {
        public int defense;

        public ArmorItem(string name, string description, int price, int value, int defense) : base(name, description, price, value)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, List<Enemy> target)
        {
            user.armor = this;
            Program.Write("you are using. it. now", 0, true);
        }
    }
}
