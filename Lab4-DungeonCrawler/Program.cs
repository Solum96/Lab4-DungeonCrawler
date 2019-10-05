using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_DungeonCrawler
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster(3, 'M'); //DEVNOTE: temp monster
            Door doorOne = new Door();
            DungeonMap map = new DungeonMap(4, 2, 0, 2);

            while (player.StepCounter <= 99)
            {
                Console.WriteLine("Steps: " + player.StepCounter);
                MapRenderer.RenderMap()
                char move = Console.ReadKey().KeyChar;
                switch (move)
                {
                    case 'w':
                        player.MovePlayer(DungeonMap.MapArray, -1, 0, monster);
                        break;

                    case 'a':
                        player.MovePlayer(DungeonMap.MapArray, 0, -1, monster);
                        break;

                    case 's':
                        player.MovePlayer(DungeonMap.MapArray, 1, 0, monster);
                        break;

                    case 'd':
                        player.MovePlayer(DungeonMap.MapArray, 0, 1, monster);
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
