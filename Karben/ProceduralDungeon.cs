using System;
using System.Collections.Generic;
using System.Text;

namespace Karben
{
    class ProceduralDungeon
    {
        public Dictionary<string, int> NpcChances { get; set; } = new Dictionary<string, int>()
        {
            { "m", monsterChance },
            { "?", randomChance },
            { "e", eliteChance },
            { "s", shopChance }
        };

        private static readonly int eliteChance = 15;
        private static readonly int monsterChance = 75;
        private static readonly int randomChance = 35;
        private static readonly int shopChance = 20;

        public Dictionary<RoomWayPoints, string> Room { get; set; } = new Dictionary<RoomWayPoints, string>();
        public RoomWayPoints PlayCoords { get; set; } = new RoomWayPoints(2, 2);
        public int IncrementOne { get; set; } = 1;

        public List<string> Splines { get; } = new List<string>() { "|\\", " /|\\ ",  "   /|" };

        public ProceduralDungeon()
        {
            PrintRoom();
        }

        public void PrintRoom()
        {
            GenerateRooom();
            foreach (KeyValuePair<RoomWayPoints, string> item in Room)
            {
                Console.WriteLine($"Monster: {item.Value} | Waypoints ({item.Key.X}, {item.Key.Y})");
            }
            foreach (KeyValuePair<RoomWayPoints, string> coords in Room)
            {

                if (coords.Key.X == IncrementOne)
                {
                    Console.WriteLine();
                    IncrementOne++;
                }
                if (coords.Key.X == 7)
                {
                    Console.WriteLine("\\ | /");
                    Console.WriteLine("  b  ");
                }
                if (coords.Key.Y == 1)
                    Console.Write($"-{coords.Value}-");
                else if (coords.Key.X != 7)
                    Console.Write($"{coords.Value}");
                if ((PlayCoords.X == coords.Key.X && coords.Key.Y == 2) && coords.Key.X != 7)
                {
                    Console.WriteLine();
                    Console.Write(Splines[PlayCoords.Y]);
                }
            }
        }

        public void GenerateRooom()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (x == 0)
                        NpcChances["e"] = 0;
                    else
                        NpcChances["e"] = eliteChance;

                    WeightChanceExecutor weightChanceExecutor = new WeightChanceExecutor(
                        new WeightedChanceParam(() =>
                        {
                            Room.Add(new RoomWayPoints(x, i), "m");
                        }, NpcChances["m"]),
                        new WeightedChanceParam(() =>
                        {
                            Room.Add(new RoomWayPoints(x, i), "?");
                        }, NpcChances["?"]),
                        new WeightedChanceParam(() =>
                        {
                            Room.Add(new RoomWayPoints(x, i), "e");
                        }, NpcChances["e"]),
                        new WeightedChanceParam(() =>
                        {
                            Room.Add(new RoomWayPoints(x, i), "s");
                        }, NpcChances["s"]));
                    weightChanceExecutor.Execute();
                }
            }
            Room.Add(new RoomWayPoints(7, 0), "b");
        }
    }
}
