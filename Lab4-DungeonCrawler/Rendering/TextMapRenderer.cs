using System;

namespace Lab4_DungeonCrawler.Rendering
{
    public class TextMapRenderer : IMapRender
    {
        public void RenderMap(DungeonMap map)
        {
            for (int x = 0; x < map.MapSize.Width; x++)
            {
                for (int y = 0; y < map.MapSize.Height; y++)
                {
                    Console.Write(map.MapArray[y, x].Visual);
                }
                Console.WriteLine();
            }
        }
    }
}