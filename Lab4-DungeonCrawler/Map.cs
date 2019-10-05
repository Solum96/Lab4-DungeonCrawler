using System;
using static Lab4_DungeonCrawler.Program;
using System.Drawing;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public class DungeonMap
    {

        public DungeonMap(int numberOfMonsters, int numberOfKeys, int numberOfTraps, int numberOfDoors, Size Size)
        {
            NumberOfMonsters = numberOfMonsters;
            NumberOfKeys = numberOfKeys;
            NumberOfTraps = numberOfTraps;
            NumberOfDoors = numberOfDoors;
            MapSize = Size;
        }

        int NumberOfMonsters { get; set; }
        int NumberOfKeys { get; set; }
        int NumberOfTraps { get; set; }
        int NumberOfDoors { get; set; }
        Size MapSize { get; set; }

        public Point CurrentPlayerLocation
        {
            get
            {
                for (int i = 0; i < MapArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MapArray.GetLength(1); j++)
                    {
                        if (MapArray[i, j].Equals('@'))
                        {
                            return new Point { X = i, Y = j };
                        }
                    }
                }
                return new Point { X = -1, Y = -1 };
            }
        }

        public GameObject[,] MapArray { get; set; }
            
        //    = new char[,]
        //{
        //    {'#', '#', '#', '#', '#', '#', '#', '#', '#'},
        //    {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
        //    {'#', '-', '-', '-', 'M', '-', '-', '-', '#'},
        //    {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
        //    {'#', '-', 'M', '-', '@', '-', '-', '-', '#'},
        //    {'#', '-', '-', '-', '-', '-', 'D', '-', '#'},
        //    {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
        //    {'#', '-', '-', '-', '-', '-', '-', '-', '#'},
        //    {'#', '#', '#', '#', '#', '#', '#', '#', '#'}
        //};
        public void GenerateMap(Size size)
        {
            var random = new Random();

            MapArray = new GameObject[size.Width, size.Height];
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    if(x == 0 || y == 0 || x == size.Width - 1 || y == size.Height - 1)
                    {
                        MapArray[x, y] = new Wall(this, new Point(x, y));
                    }
                    else
                    {
                        MapArray[x, y] = new Floor(this, new Point(x, y));
                    }
                }
            }
            for (int i = 0; i < NumberOfDoors; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2));
                MapArray[location.X, location.Y] = new Door(this, location);
            }
            for (int i = 0; i < NumberOfMonsters; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2));
                MapArray[location.X, location.Y] = new Monster(random.Next(5, 10), this, location);
            }
            for (int i = 0; i < NumberOfKeys; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2));
                MapArray[location.X, location.Y] = new Key(this, location);
            }
            for (int i = 0; i < NumberOfTraps; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2));
                MapArray[location.X, location.Y] = new Trap(this, location);
            }
        }

        public void MovePlayerInMap(Point currentLocation, Point futureLocation)
        {
            ResetAtLocation(currentLocation);
            MapArray[futureLocation.Y, futureLocation.X] = new Player(this, futureLocation);
        }

        public void ResetAtLocation(Point point)
        {
            MapArray[point.Y, point.X] = new Floor(this, point);
        }

        public bool IsMonster(Point Point) => MapArray[Point.Y, Point.X].GetType() == typeof(Monster) ;
        public bool IsDoor(Point Point) => MapArray[Point.Y, Point.X].GetType() == typeof(Door);
        public bool IsWall(Point Point) => MapArray[Point.Y, Point.X].GetType() == typeof(Wall);
        public bool IsKey(Point Point) => MapArray[Point.Y, Point.X].GetType() == typeof(Key);
        public bool IsTrap(Point Point) => MapArray[Point.Y, Point.X].GetType() == typeof(Trap);
    }
}