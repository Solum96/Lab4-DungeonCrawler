using System;
using System.Drawing;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public class DungeonMap
    {
        public DungeonMap(int numberOfMonsters, int numberOfKeys, int numberOfTraps, int numberOfDoors, int numberOfPrizes, Size size)
        {
            NumberOfMonsters = numberOfMonsters;
            NumberOfKeys = numberOfKeys;
            NumberOfTraps = numberOfTraps;
            NumberOfDoors = numberOfDoors;
            NumberOfPrizes = numberOfPrizes;
            MapSize = size;
            GenerateMap(size);
        }

        private int NumberOfMonsters { get; set; }
        private int NumberOfKeys { get; set; }
        private int NumberOfTraps { get; set; }
        private int NumberOfDoors { get; set; }
        private int NumberOfPrizes { get; set; }
        public Size MapSize { get; set; }
        public int NumberOfLevels { get; set; } = 0;

        public GameObject GetGameObjectAt(Point location)
        {
            return MapArray[location.X, location.Y];
        }

        public Point CurrentPlayerLocation { get; set; }

        public GameObject[,] MapArray { get; set; }

        public void GenerateMap(Player player, Size size)
        {
            NumberOfLevels++;
            var random = new Random();

            MapArray = new GameObject[size.Width, size.Height];
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    if (x == 0 || y == 0 || x == size.Width - 1 || y == size.Height - 1)
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
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                MapArray[location.X, location.Y] = new Door(this, location);
            }
            for (int i = 0; i < NumberOfMonsters; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                MapArray[location.X, location.Y] = new Monster(random.Next(5, 10), this, location);
            }
            for (int i = 0; i < NumberOfKeys; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                MapArray[location.X, location.Y] = new Key(this, location);
            }
            for (int i = 0; i < NumberOfTraps; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                MapArray[location.X, location.Y] = new Trap(random.Next(2, 5), this, location);
            }
            for (int i = 0; i < NumberOfPrizes; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                MapArray[location.X, location.Y] = new Prize(random.Next(5, 10), this, location);
            }
            var newPosition = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));

            while (GetGameObjectAt(newPosition).GetType() != typeof(Floor))
            {
                newPosition = new Point(random.Next(1, size.Width - 2));
            }

            if (NumberOfLevels == 0)
            {
                MapArray[newPosition.X, newPosition.Y] = new Player(this, newPosition);
                CurrentPlayerLocation = newPosition;
            }
            else
            {
                CurrentPlayerLocation = newPosition;
            }
        }

        public void MovePlayerInMap(Point currentLocation, Point futureLocation)
        {
            var player = MapArray[currentLocation.X, currentLocation.Y];
            ResetAtLocation(currentLocation);
            MapArray[futureLocation.X, futureLocation.Y] = player;
        }

        public void ResetAtLocation(Point point)
        {
            MapArray[point.X, point.Y] = new Floor(this, point);
        }

        public bool IsMonster(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Monster);
        public bool IsDoor(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Door);
        public bool IsWall(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Wall);
        public bool IsKey(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Key);
        public bool IsTrap(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Trap);
        public bool IsPrize(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Prize);

    }
}