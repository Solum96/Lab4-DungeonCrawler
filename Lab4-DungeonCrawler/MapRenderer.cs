using System;

namespace Lab4_DungeonCrawler
{
    public class MapRenderer
    {
        public static void RenderMap(DungeonMap map)
        {
            for (int row = 0; row < map.MapArray.GetLength(0); row++)
            {
                for (int column = 0; column < map.MapArray.GetLength(1); column++)
                {
                    Console.Write(map.MapArray[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}