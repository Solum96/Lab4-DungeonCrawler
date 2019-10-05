using System;
using static Lab4_DungeonCrawler.Program;

namespace Lab4_DungeonCrawler
{
    internal class Map : GameObject
    {

        public Map(int NumberOfMonsters, int NumberOfKeys, int NumberOfTraps, int NumberOfDoors)
        {
            this.NumberOfMonsters = NumberOfMonsters;
            this.NumberOfKeys = NumberOfKeys;
            this.NumberOfTraps = NumberOfTraps;
            this.NumberOfDoors = NumberOfDoors;
        }

        static int MapHeight { get; set; } = 15;
        static int MapWidth { get; set; } = 20;

        int NumberOfMonsters { get; set; } = 5;
        int NumberOfKeys { get; set; } = 2;
        int NumberOfTraps { get; set; } = 8;
        int NumberOfDoors { get; set; } = 2;

        public static char[,] mapArray = new char[,]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
            {'#', '-', '-', '-', 'M', '-', '-', '-', '#'},
            {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
            {'#', '-', 'M', '-', '@', '-', '-', '-', '#'},
            {'#', '-', '-', '-', '-', '-', 'D', '-', '#'},
            {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
            {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        public static bool IsMonster(int y, int x)
        {
            if (mapArray[y, x] == 'M') { return true; }
            else { return false; }
        }
    }
}