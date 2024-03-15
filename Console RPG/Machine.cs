using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Console_RPG
{
    class Machine
    {
        public static string[] slotSymbols = new string[] { "7", "☻", "♥", "♦", "√", "$", "?", "7", "☻" };

        public static Machine[] machines = new Machine[] {
        new Machine("NO <MACHINE>", "null", 0, 0),
        new Machine("POOR <MACHINE>", "5000C!!", 5000, 100),
        new Machine("HUMBLE <MACHINE>", "10000,!", 10000, 250),
        new Machine(" <MACHIN<MACHINE>", "50000?@", 50000, 500),
        new Machine("RICH <MACHINE>", "1000000", 1000000, 1000),
        new Machine("THE <MACHINE>", "??KEY??", 0, 10000) };

        public string name;
        public string jackpotName;
        public int jackpotValue;
        public int cost;

        public Machine(string name, string jackpotName, int jackpotValue, int cost)
        {
            this.name = name;
            this.jackpotName = jackpotName;
            this.jackpotValue = jackpotValue;
            this.cost = cost;
        }

        public static void Gamble(int machine)
        {
            if (machine > 0 && machines[machine].cost <= Player.player.coins)
            {
                Player.player.coins -= machines[machine].cost;
                Random rand = new Random();
                int[] results = new int[] { };
                if (Player.player.inventory.Contains(Item.machineRigger))
                {
                    results = new int[] { rand.Next(rand.Next(4, 8), 8), rand.Next(rand.Next(4, 8), 8), rand.Next(rand.Next(4, 8), 8) };
                }
                else
                {
                    results = new int[] { rand.Next(1, 8), rand.Next(1, 8), rand.Next(1, 8) };
                }
                Program.WriteSlow($"         .-------.e         |Jackpot|e         |{machines[machine].jackpotName}|e   ______|_______|______e  |        SLOTS        |e  |===___===___===___===|e  ||*|   |*|   |*|   |*||e  ||*| {slotSymbols[results[0] - 1]} |*| {slotSymbols[results[1] - 1]} |*| {slotSymbols[results[2] - 1]} |*|| __e  ||*|___|*|___|*|___|*||(__)e  |===___===___===___===| ||e  ||>|   |*|   |*|   |<|| ||e  ||>| {slotSymbols[results[0]]} |*| {slotSymbols[results[1]]} |*| {slotSymbols[results[2]]} |<|| ||e  ||>|___|*|___|*|___|<||_//e  |===___===___===___===|_/e  ||*|   |*|   |*|   |*||e  ||*| {slotSymbols[results[0] + 1]} |*| {slotSymbols[results[1] + 1]} |*| {slotSymbols[results[2] + 1]} |*||      e  ||*|___|*|___|*|___|*||e  |===_______________===|e  |  /_______________\\  |e _|  \\_______________/  |_e(_________________________)".Replace("e", Environment.NewLine), 10, 5, 1000, true);
                int prize = 0;
                if (results[0] == results[1] && results[0] == results[2])
                {
                    if (results[0] < 5)
                    {
                        Player.player.coins += prize = machines[machine].cost * results[0];
                    }
                    else if (results[0] == 5)
                    {
                        Player.player.coins += prize = machines[machine].cost * 7;
                    }
                    else if (results[0] == 6)
                    {
                        Player.player.coins += prize = machines[machine].cost * rand.Next(1, 10);
                    }
                    else
                    {
                        Player.player.coins += prize = machines[machine].jackpotValue;
                        if (machine == 5 && machines[5].jackpotValue == 0)
                        {
                            Console.WriteLine("Youwon.,YouWon!!<<<<<??Key??");
                            Player.player.inventory.Add(Item.key);
                            machines[5] = new Machine("VIP <MACHINE>", "BILLION", 1000000000, 10000);
                        }
                    }
                }
                else if (results[0] == results[1] || results[0] == results[2] || results[1] == results[2])
                {
                    int sing;
                    int dupe;
                    if (results[0] == results[1])
                    {
                        sing = results[2];
                        dupe = results[0];
                    }
                    else if (results[0] == results[2])
                    {
                        sing = results[1];
                        dupe = results[0];
                    }
                    else
                    {
                        sing = results[0];
                        dupe = results[2];
                    }
                    Player.player.coins += prize = (int)(sing / 21f * machines[machine].cost) + (int)(dupe / 21f * machines[machine].cost * 7);
                }
                else
                {
                    Player.player.coins += prize = (int)((results[0] + results[1] + results[2]) / 21f * machines[machine].cost);
                }
                if (prize < machines[machine].cost)
                {
                    Console.WriteLine("NET LOSS | " + -(prize - machines[machine].cost));
                }
                else
                {
                    Console.WriteLine("NET GAIN | " + (prize - machines[machine].cost));
                }
                Console.WriteLine();
            }
        }
    }
}
//         .-------.
//         |Jackpot|
//         |[money]|
//   ______|_______|______
//  |        SLOTS        |
//  |===___===___===___===|
//  ||*|   |*|   |*|   |*||
//  ||*| O |*| O |*| O |*|| __
//  ||*|___|*|___|*|___|*||(__)
//  |===___===___===___===| ||
//  ||>|   |*|   |*|   |<|| ||
//  ||>| O |*| O |*| O |<|| ||
//  ||>|___|*|___|*|___|<||_//
//  |===___===___===___===|_/
//  ||*|   |*|   |*|   |*||
//  ||*| O |*| O |*| O |*||      
//  ||*|___|*|___|*|___|*||
//  |===_______________===|
//  |  /_______________\  |
// _|  \_______________/  |_
//(_________________________)
