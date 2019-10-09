using System;
using System.Drawing;
using Lab4_DungeonCrawler.Rendering;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public class Game
    {
        public Game()
        {
            Map = new DungeonMap(5, 1, 4, 1, 5, new Size(20, 15));
            Player = new Player(Map, Map.CurrentPlayerLocation);
        }
        private DungeonMap Map { get; set; }
        public static Player Player { get; set; }

        private IMapRender Renderer { get; set; } = new TextMapRenderer(); // Will be injected through DI in the future! ;)
        
        public void RunGame()
        {
            while (Map.NumberOfLevels <= 3)
            {
                Console.WriteLine("Steps: " + Player.StepCounter);
                if (Player.HasKey) { Console.WriteLine("You have a key."); }
                else { Console.WriteLine("You don't have a key."); }
                Renderer.RenderMap(Map);
                char move = Console.ReadKey().KeyChar;
                switch (move)
                {
                    case 'a':
                        Player.MovePlayer(new MoveDelta() { DeltaX = 0, DeltaY = -1 });
                        break;

                    case 'w':
                        Player.MovePlayer(new MoveDelta() { DeltaX = -1, DeltaY = 0 });
                        break;

                    case 'd':
                        Player.MovePlayer(new MoveDelta() { DeltaX = 0, DeltaY = 1 });
                        break;

                    case 's':
                        Player.MovePlayer(new MoveDelta() { DeltaX = 1, DeltaY = 0 });
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
