using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Console_RPG
{
    struct Stats
    {
        public int attack;
        public int defence;
        public int maxHP;

        public Stats(int attack, int defence, int maxHP)
        {
            this.attack = attack;
            this.defence = defence;
            this.maxHP = maxHP;
        }
    }

    abstract class Entity
    {
        public string name;
        public int exp;
        public int hp;
        public int coins;

        public Stats stats;
        public List<Item> inventory;
        public WeaponItem weapon;
        public ArmorItem armor;

        public Entity(string name, int exp, int hp, int coins, Stats stats, List<Item> inventory, WeaponItem weapon = null, ArmorItem armor = null)
        {
            this.name = name;
            this.exp = exp;
            this.hp = hp;
            this.coins = coins;
            this.stats = stats;
            this.inventory = inventory;
            this.weapon = weapon;
            this.armor = armor;
        }

        public abstract void DoTurn(List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Enemy> choices);
        public abstract void Attack(Entity target);
    }

    class Player : Entity
    {
        public static Player player = new Player("", 1, 0, 1, 25, 0, new Stats(1, 1, 25), new List<Item> { Item.weaponI, Item.armorI }, new List<Recipe> { }, Item.weaponI, Item.armorI);
        //public static Player player = new Player("prefinal", 42, 19, 83, 230, 1000000000, new Stats(83, 42, 230), new List<Item> { Item.weaponI, Item.armorI, Item.weaponVI, Item.armorVI, Item.map, Item.infinityObject, Item.whopper, Item.hugeFortune }, new List<Recipe> { Recipe.recipeI, Recipe.recipeII , Recipe.recipeIII , Recipe.recipeIV , Recipe.recipeV , Recipe.recipeVI , Recipe.recipeVII , Recipe.recipeVIII , Recipe.recipeIX , Recipe.recipeX }, Item.weaponVI, Item.armorVI);
        //public static Player player = new Player("god", 999, 0, 1, 999, 99999999, new Stats(9999, 999, 999), new List<Item> { Item.weaponI, Item.armorI, Item.foodVI, Item.whopper, Item.map }, new List<Recipe> { }, Item.weaponI, Item.armorI);

        public int level;
        public int maxExp;
        public int critChance;
        public List<Recipe> recipes;

        public static bool defending;
        public static bool flee;

        public Player(string name, int level, int exp, int maxExp, int hp, int coins, Stats stats, List<Item> inventory, List<Recipe> recipes, WeaponItem weapon, ArmorItem armor) : base(name, exp, hp, coins, stats, inventory, weapon, armor) 
        {
            this.level = level;
            this.maxExp = maxExp;
            this.recipes = recipes;
        }

        public override Entity ChooseTarget(List<Enemy> choices)
        {
            if (choices.Count != 1)
            {
                Console.WriteLine("<-CHOOSE WAY->");
                for (int o = 0; o < choices.Count; o++)
                {
                    Console.WriteLine(o + ": " + choices[o].name);
                }
                return choices[Program.InputInt(0, choices.Count - 1)];
            }
            else
                return choices[0];
        }

        public override void DoTurn(List<Enemy> enemies)
        {
            defending = false;
            Random rand = new Random();
            Program.Write("(A) Attack><", 0, true);
            Console.WriteLine("(D) Defend<>");
            Console.WriteLine("(I) Itemv^");
            Console.WriteLine("(F) Flee^v");
            string choice = Program.InputString(new List<string> { "A", "D", "I", "F" }, "Pick(Pick)Pick an action. ction k an a .");
            Console.WriteLine();
            if (choice == "A")
                Attack(ChooseTarget(enemies));
            else if (choice == "D")
            {
                defending = true;
                critChance = 0;
                Program.Write("Defended.(ing.).", 1000, true);
            }
            else if (choice == "I")
                Program.GetInventory(enemies);
            else if (rand.Next(0, 3) == 0)
            {
                Console.WriteLine("escape (did)");
                flee = true;
            }
            else
                Program.Write("escape (not)", 1000, true);
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            int damage = 0;
            if (rand.Next(0, critChance) == 0)
            {
                damage = (Int32)(MathF.Max(stats.attack + weapon.damage - target.stats.defence, 1) * 1.5f);
                critChance = 10;
                Console.WriteLine("Cr1t{}");
            }
            else
                damage = (Int32)(MathF.Max(stats.attack + weapon.damage - target.stats.defence, 1) * (rand.Next(9, 11) / 10f));
            target.hp -= damage;
            Program.Write($"{target.name} MINUS {damage}", 1000, true);
        }
    }

    class Enemy : Entity
    {
        public static Enemy rat = new Enemy("rat", 1, 10, 1, new Stats(4, 0, 10));
        public static Enemy entity = new Enemy("[Entity]", 5, 25, 10, new Stats(9, 1, 25));
        public static Enemy rose = new Enemy("Rose", 7, 23, 6, new Stats(18, 6, 23));
        public static Enemy sunflower = new Enemy("_SunFlower", 4, 12, 7, new Stats(12, 4, 12));
        public static Enemy stopSign = new Enemy("<STOP>", 8, 80, 0, new Stats(15, 15, 80));
        public static Enemy seed = new Enemy("sEEdling", 2, 5, 2, new Stats(10, 5, 5));
        public static Enemy wind = new Enemy("b r e e z e", 1, 1, 1, new Stats(1, 0, 1));
        public static Enemy tumbleweed = new Enemy("deewelbmut", 9, 50, 14, new Stats(25, 9, 50));
        public static Enemy anglerfish = new Enemy("ANGLER fish", 13, 55, 11, new Stats(42, 3, 55));
        public static Enemy silhouette = new Enemy("SILHOUETTE?", 17, 66, 23, new Stats(29, 12, 66));
        public static Enemy easyEntity = new Enemy("EASY:Entity:", 10, 2, 10, new Stats(1, 1, 2));
        public static Enemy hardEntity = new Enemy("HARD:Entity:", 66, 100, 100, new Stats(50, 30, 100));
        public static Enemy brick = new Enemy("|=|", 5, 70, 15, new Stats(30, 30, 70));
        public static Enemy coinI = new Enemy("(coin)", 0, 10, 1, new Stats(2, 5, 10));
        public static Enemy coinII = new Enemy("Coin=Stack", 0, 20, 10, new Stats(5, 8, 20));
        public static Enemy coinIII = new Enemy("UcoinUbagU", 0, 25, 50, new Stats(10, 10, 25));
        public static Enemy coinIV = new Enemy("||COINSAFE||", 0, 100, 150, new Stats(40, 50, 100));
        public static Enemy dot = new Enemy(".", 11, 11, 11, new Stats(11, 11, 11));
        public static Enemy triangle = new Enemy("▲", 33, 66, 33, new Stats(30, 15, 66));
        public static Enemy square = new Enemy("■", 44, 44, 44, new Stats(40, 20, 44));
        public static Enemy leftParenthesi = new Enemy("(", 50, 150, 50, new Stats(60, 50, 150));
        public static Enemy rightParenthesi = new Enemy(")", 50, 150, 50, new Stats(60, 50, 150));
        public static Enemy tree = new Enemy("tr ee", 7, 30, 12, new Stats(12, 7, 30));
        public static Enemy grass = new Enemy("^^^^^", 3, 15, 2, new Stats(6, 3, 15));
        public static Enemy meatling = new Enemy("meatling", 10, 50, 4, new Stats(25, 15, 50));
        public static Enemy bee = new Enemy("B", 0, 20, 5, new Stats(33, 16, 20));
        public static Enemy goblin = new Enemy("gooblinu", 0, 43, 36, new Stats(45, 25, 43));
        public static Enemy book = new Enemy("(bo()ok)", 0, 32, 3, new Stats(53, 39, 32));
        public static Enemy info = new Enemy("INFORMATION", 0, 64, 99, new Stats(62, 27, 64));

        public static Enemy bigBee = new Enemy("!!THE!!bee---;", 100, 150, 150, new Stats(55, 33, 150), new List<Item> { Item.honeyEsscence }, new List<Enemy> { bee }, 3);
        public static Enemy witch = new Enemy("W!!Witch!!{}", 150, 200, 1200, new Stats(66, 45, 200), new List<Item> { Item.machineRigger }, new List<Enemy> { rat, goblin }, 2);
        public static Enemy boss = new Enemy("!!The_-_BOSS!!", 200, 250, 1000000, new Stats(85, 55, 250), new List<Item> { Item.hugeFortune }, new List<Enemy> { coinI, coinII, coinIII }, 3);
        public static Enemy librarian = new Enemy("knowledge-::!!Librarian.!!::-", 250, 300, 0, new Stats(100, 90, 300), new List<Item> { Item.allKnowledge }, new List<Enemy> { book, info }, 2);
        public static Enemy infinityEntity = new Enemy("EVERYTHINGTHATISOREVERWILLBE", 8300, 900, 0, new Stats(150, 100, 900), null, new List<Enemy> { rat, entity, rose, sunflower, stopSign, seed, wind, tumbleweed, anglerfish, silhouette, easyEntity, hardEntity, brick, coinI, coinII, coinIII, coinIV, dot, triangle, square, leftParenthesi, rightParenthesi, tree, grass, meatling, bee }, 1);
        public static Enemy you = new Enemy("", 0, 0, 0, new Stats(0, 0, 0));

        public List<Enemy> spawn;
        public int spawnInterval;

        public Enemy(string name, int exp, int hp, int coins, Stats stats, List<Item> inventory = null, List<Enemy> spawn = null, int spawnInterval = 0) : base(name, exp, hp, coins, stats, inventory)
        {
            this.spawn = spawn;
            this.spawnInterval = spawnInterval;
        }

        public override void DoTurn(List<Enemy> enemies)
        {
            Attack(Player.player);
        }

        public override Entity ChooseTarget(List<Enemy> choices)
        {
            return Player.player;
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            int damage = 0;
            if (Player.defending)
                target.hp -= damage = (Int32)(MathF.Max(stats.attack - target.stats.defence - target.armor.defense, 1) * (rand.Next(3, 6) / 10f));
            else
                target.hp -= damage = (Int32)(MathF.Max(stats.attack - target.stats.defence - target.armor.defense, 1) * (rand.Next(9, 11) / 10f));
            Program.Write($"{target.name} MINUS {damage}", 500, true);
        }
    }
}
