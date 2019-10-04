using System;

namespace Lab4_DungeonCrawler
{
    internal class Map
    {
        
        public static char[,] mapArray = new char[,]
        {
<<<<<<< HEAD
            {'#', '#', '#', '#', '#', '#', '#', '#', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '@', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
            {'#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
=======
            char[,] mapArray = new char[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '@', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '-', '-', '-', '-', '-', '-', '-', '#' },
                {'#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            while (true)
            {
                for (int row = 0; row < mapArray.GetLength(0); row++)
                {
                    for (int column = 0; column < mapArray.GetLength(1); column++)
                    {
                        Console.Write(mapArray[row, column]);
                    }
                    Console.WriteLine();
                }
                char move = Console.ReadKey().KeyChar;
                switch (move)
                {
                    case 'w':
                        Player.MovePlayer(mapArray, -1, 0);
                        break;

                    case 'a':
                        Player.MovePlayer(mapArray, 0, -1);
                        break;

                    case 's':
                        Player.MovePlayer(mapArray, 1, 0);
                        break;

                    case 'd':
                        Player.MovePlayer(mapArray, 0, 1);
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }
        }
>>>>>>> 5abded62349f2367b3452a51c294a028cd337605
    }
}