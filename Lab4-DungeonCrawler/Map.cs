using System;

namespace Lab4_DungeonCrawler
{
    internal class Map
    {
        public static void CreateMapArray()
        {
            char[,] mapArray = new char[,]
            {
                {'#', '#', '#', '#', '#' },
                {'#', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '#' },
                {'#', '-', '@', '-', '#' },
                {'#', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '#' },
                {'#', '#', '#', '#', '#' }
            };
        }
    }
}