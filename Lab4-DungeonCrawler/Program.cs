using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster(3, 'M');
            while (true)
            {
                for (int row = 0; row < Map.mapArray.GetLength(0); row++)
                {
                    for (int column = 0; column < Map.mapArray.GetLength(1); column++)
                    {
                        Console.Write(Map.mapArray[row, column]);
                    }
                    Console.WriteLine();
                }
                char move = Console.ReadKey().KeyChar;
                switch (move)
                {
                    case 'w':
                        Player.MovePlayer(Map.mapArray, -1, 0, monster);
                        break;

                    case 'a':
                        Player.MovePlayer(Map.mapArray, 0, -1, monster);
                        break;

                    case 's':
                        Player.MovePlayer(Map.mapArray, 1, 0, monster);
                        break;

                    case 'd':
                        Player.MovePlayer(Map.mapArray, 0, 1, monster);
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
