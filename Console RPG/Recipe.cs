using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    internal class Recipe
    {
        public static Recipe recipeI = new Recipe(new List<Item> { Item.honeyEsscence, Item.foodIX, Item.healthPotionIII }, Item.antiForceField);
        public static Recipe recipeII = new Recipe(new List<Item> { Item.healthPotionII, Item.healthPotionIII }, Item.healthPotionIV);
        public static Recipe recipeIII = new Recipe(new List<Item> { Item.healthPotionIV, Item.foodB, Item.foodVIII, }, Item.healthPotionV);
        public static Recipe recipeIV = new Recipe(new List<Item> { Item.healthPotionII, Item.foodIV }, Item.damagePotionI);
        public static Recipe recipeV = new Recipe(new List<Item> { Item.damagePotionI, Item.foodVI }, Item.damagePotionII);
        public static Recipe recipeVI = new Recipe(new List<Item> { Item.damagePotionII, Item.foodVI, Item.foodI, Item.foodVIII }, Item.damagePotionIII);
        public static Recipe recipeVII = new Recipe(new List<Item> { Item.bombI, Item.foodVII, Item.foodIII }, Item.bombII);
        public static Recipe recipeVIII = new Recipe(new List<Item> { Item.bombII, Item.foodVI, Item.damagePotionII }, Item.bombIII);
        public static Recipe recipeIX = new Recipe(new List<Item> { Item.weaponV, Item.foodB, Item.damagePotionII, Item.foodVIII }, Item.weaponVI);
        public static Recipe recipeX = new Recipe(new List<Item> { Item.armorIV, Item.tungsten, Item.foodVIII }, Item.armorVI);

        public List<Item> ingredients;
        public Item outgredient;

        public Recipe(List<Item> ingredients, Item outgredient)
        {
            this.ingredients = ingredients;
            this.outgredient = outgredient;
        }
        public static void Resolve()
        {
            bool cooking = true;
            while (cooking)
            {
                Console.Clear();
                Console.WriteLine("Recipes :CRAFT.craft(lab)");
                for (int r = 0; r < Player.player.recipes.Count; r++)
                {
                    Console.Write($"{r}) {Player.player.recipes[r].outgredient.name} = ");
                    if (Player.player.inventory.Contains(Player.player.recipes[r].ingredients[0]))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Player.player.recipes[r].ingredients[0].name);
                    for (int i = 1; i < Player.player.recipes[r].ingredients.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" + ");
                        if (Player.player.inventory.Contains(Player.player.recipes[r].ingredients[i]))
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Player.player.recipes[r].ingredients[i].name);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                Console.WriteLine(Player.player.recipes.Count + ") GET OUT");
                Program.Write("", 1000, true);
                Program.Write("Your :Things.things(pocket)", 0, true);
                Program.ShowInventory();
                int recipeChosen = Program.InputInt(0, Player.player.recipes.Count);
                if (recipeChosen != Player.player.recipes.Count)
                {
                    bool craftable = true;
                    foreach (Item item in Player.player.recipes[recipeChosen].ingredients)
                        if (!Player.player.inventory.Contains(item))
                            craftable = false;
                    if (craftable)
                    {
                        foreach (Item item in Player.player.recipes[recipeChosen].ingredients)
                            Player.player.inventory.Remove(item);
                        Player.player.inventory.Add(Player.player.recipes[recipeChosen].outgredient);
                    }
                }
                else
                    cooking = false;
            }
        }
    }
}
