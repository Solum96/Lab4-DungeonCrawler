using System;
using static Lab4_DungeonCrawler.Program;

namespace Lab4_DungeonCrawler
{
    public class Map : GameObject
    {

        public Map(int NumberOfMonsters, int NumberOfKeys, int NumberOfTraps, int NumberOfDoors)
        {
            this.NumberOfMonsters = NumberOfMonsters;
            this.NumberOfKeys = NumberOfKeys;
            this.NumberOfTraps = NumberOfTraps;
            this.NumberOfDoors = NumberOfDoors;
        }

        int NumberOfMonsters { get; set; } = 5;
        int NumberOfKeys { get; set; } = 2;
        int NumberOfTraps { get; set; } = 8;
        int NumberOfDoors { get; set; } = 2;

        public Coordinate FindStartLocation
        {
            get
            {
                for (int i = 0; i < mapArray.GetLength(0); i++)
                {
                    for (int j = 0; j < mapArray.GetLength(1); j++)
                    {
                        if (mapArray[i, j].Equals('@'))
                        {
                            return new Coordinate { ColumnIndex = i, RowIndex = j };
                        }
                    }
                }
                return new Coordinate { ColumnIndex = -1, RowIndex = -1 };
            }
        }

        private char[,] mapArray = new char[,]
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

        public bool IsMonster(int y, int x)
        {
            if (mapArray[y, x] == 'M') { return true; }
            else { return false; }
        }

        public bool IsDoor(int y, int x)
        {
            if (mapArray[y, x] == 'D') { return true; }
            else { return false; }
        }
    }
}