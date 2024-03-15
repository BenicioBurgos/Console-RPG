using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Console_RPG
{
    class Battle
    {
        public static int spawnCooldown;
        public static List<Enemy> bossSpawn;
        public static int bossTurn;
        public static bool finalBoss;

        public List<Enemy> enemies;
        public bool boss;

        public Battle(List<Enemy> enemies, bool boss = false)
        {
            this.enemies = enemies;
            this.boss = boss;
        }

        public void Resolve(Player player)
        {
            List<Enemy> fightEnemies = new List<Enemy>();
            int prizeExp = 0;
            int prizeCoins = 0;
            List<Item> prizeItems = new List<Item>();
            bossTurn = 0;
            bool lost = false;
            bool bossDead = false;
            foreach (Enemy enemy in enemies)
            {
                if (enemy.spawn != null)
                {
                    bossSpawn = enemy.spawn;
                    spawnCooldown = enemy.spawnInterval;
                }
                fightEnemies.Add(new Enemy(enemy.name, enemy.exp, enemy.hp, enemy.coins, enemy.stats, enemy.inventory));
            }
            while (player.hp > 0 && fightEnemies.Count > 0 && (!Player.flee || finalBoss))
            {
                Console.Clear();
                Console.WriteLine($"You -- {Program.Bar(Player.player.stats.maxHP, Player.player.hp, 10)}");
                Console.WriteLine();
                for (int e = 0; e < fightEnemies.Count; e++)
                {
                    if (boss && e == 0)
                        Console.WriteLine($"{fightEnemies[e].name} -- {Program.Bar(fightEnemies[e].stats.maxHP, fightEnemies[e].hp, 25)}");
                    else
                        Console.WriteLine($"{fightEnemies[e].name} -- {Program.Bar(fightEnemies[e].stats.maxHP, fightEnemies[e].hp, 10)}");
                }
                Program.Write("", 500, true);
                Player.player.DoTurn(fightEnemies);
                if (finalBoss)
                {
                    player.hp = fightEnemies[0].hp;
                }
                else if (!Player.flee)
                {
                    bossTurn++;
                    if (boss && bossTurn == spawnCooldown)
                    {
                        Random rand = new Random();
                        bossTurn = 0;
                        int choice = rand.Next(0, bossSpawn.Count);
                        fightEnemies.Add(new Enemy(bossSpawn[choice].name, 0, bossSpawn[choice].hp, bossSpawn[choice].coins, bossSpawn[choice].stats));
                        Program.Write($"SUMMONS {bossSpawn[choice].name}", 500, true);
                    }
                    List<int> dead = new List<int> { };
                    for (int e = 0; e < fightEnemies.Count; e++)
                    {
                        if (fightEnemies[e].hp > 0 && !bossDead)
                            fightEnemies[e].DoTurn(null);
                        else
                        {
                            if (boss && e == 0)
                                bossDead = true;
                            prizeExp += fightEnemies[e].exp;
                            prizeCoins += fightEnemies[e].coins;
                            if (fightEnemies[e].inventory != null)
                                foreach (Item item in fightEnemies[e].inventory)
                                    prizeItems.Add(item);
                            dead.Add(e);
                        }
                    }
                    for (int d = 0; d < dead.Count; d++)
                    {
                        fightEnemies.Remove(fightEnemies[dead[d] - d]);
                        if (!boss)
                            enemies.Remove(enemies[dead[d] - d]);
                    }
                }
                Console.ReadLine();
            }
            if (finalBoss)
            {
                Console.Clear();
                Program.Write("You fail.", 2000, true);
                Program.WriteSlow("You try again.", 50, 1, 500, true);
                Program.Write("You fail again.", 2000, true);
                Program.WriteSlow("You cannot win a battle against yourself.", 50, 1, 2000, true);
                Program.WriteSlow("You try again anyways.", 50, 1, 500, true);
                Program.Write("You fail again.", 2000, true);
                for (int l = 2000; l > 0; l = (Int32)MathF.Floor(l * 0.95f))
                    Program.Write("You fail again.", l, false);
                Program.WriteSlow("You give up.", 200, 1, 5000, true);
                while (true)
                {
                    Console.Clear();
                    Console.ReadLine();
                    Program.Write("There's nothing left.", 2000, false);
                }
            }
            else
            {
                if (player.hp <= 0)
                    lost = true;
                if (Player.flee)
                    Console.WriteLine("You. Fled. Congrats, you Fled! congrats...");
                else if (player.hp > 0)
                {
                    Console.WriteLine("You. Win. Congrats, you Win! congrats...");
                    foreach (Item item in prizeItems)
                    {
                        Console.WriteLine("+" + item.name);
                        Player.player.inventory.Add(item);
                    }
                    Console.WriteLine("+$$$" + prizeCoins);
                    Player.player.coins += prizeCoins;
                }
                else
                {
                    int loss = Player.player.coins / 10;
                    Console.WriteLine("You. Lost. Congrats, you Lost! congrats...");
                    Console.WriteLine("-$$" + loss);
                    Player.player.coins -= loss;
                }
                Console.WriteLine("+" + prizeExp);
                Player.player.exp += prizeExp;
                while (Player.player.exp >= Player.player.maxExp)
                {
                    Program.Write("LEVEL    up.!", 1000, true);
                    Player.player.level++;
                    Player.player.stats.maxHP += 5;
                    Player.player.hp = Player.player.stats.maxHP;
                    Player.player.stats.attack += 2;
                    Player.player.stats.defence++;
                    Player.player.exp -= Player.player.maxExp;
                    Player.player.maxExp += 2;
                }
                Console.ReadLine();
                Console.Clear();
                if (lost)
                {
                    Player.player.hp = Player.player.stats.maxHP;
                    Player.flee = false;
                    Location.locationI.Resolve(true);
                }
            }
        }
    }
}