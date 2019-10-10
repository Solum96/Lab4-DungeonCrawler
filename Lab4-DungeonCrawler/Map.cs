using System;
using System.Drawing;
using Lab4_DungeonCrawler.GameObjects;

namespace Lab4_DungeonCrawler
{
    public class DungeonMap
    {
        public DungeonMap(int numberOfMonsters, int numberOfMultiKeys, int numberOfKeys, int numberOfTraps, int numberOfDoors, int numberOfPrizes, Size size)
        {
            NumberOfMonsters = numberOfMonsters;
            NumberOfMultiKeys = numberOfMultiKeys;
            NumberOfKeys = numberOfKeys;
            NumberOfTraps = numberOfTraps;
            NumberOfDoors = numberOfDoors;
            NumberOfPrizes = numberOfPrizes;
            MapSize = size;
            GenerateMap(size);
        }

        private int NumberOfMonsters { get; set; }
        private int NumberOfMultiKeys { get; set; }
        private int NumberOfKeys { get; set; }
        private int NumberOfTraps { get; set; }
        private int NumberOfDoors { get; set; }
        private int NumberOfPrizes { get; set; }
        public Size MapSize { get; set; }
        public int NumberOfLevels { get; set; } = 0;

        public GameObject GetGameObjectAt(Point location)
        {
            return MapArray[location.Y, location.X];
        }

        public Point CurrentPlayerLocation { get; set; }

        public GameObject[,] MapArray { get; set; }

        public void GenerateMap(Size size)
        {
            NumberOfLevels++;
            var random = new Random();

            MapArray = new GameObject[size.Height, size.Width];
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    if (x == 0 || y == 0 || x == size.Width - 1 || y == size.Height - 1)
                    {
                        MapArray[y, x] = new Wall(this, new Point(x, y));
                    }
                    else
                    {
                        MapArray[y, x] = new Floor(this, new Point(x, y));
                    }
                }
            }
            // Generating and placing doors.
            for (int i = 0; i < NumberOfDoors; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                while (GetGameObjectAt(location).GetType() != typeof(Floor))
                {
                    location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                }
                MapArray[location.Y, location.X] = new Door(this, location);
            }
            // Generating and placing monsters.
            for (int i = 0; i < NumberOfMonsters; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                while (GetGameObjectAt(location).GetType() != typeof(Floor))
                {
                    location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                }
                MapArray[location.Y, location.X] = new Monster(random.Next(5, 10), this, location);
            }
            // Generating and placing multikeys.
            if (NumberOfMultiKeys == 1)
            {
                for (int i = 0; i < NumberOfMultiKeys; i++)
                {
                    var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                    while (GetGameObjectAt(location).GetType() != typeof(Floor))
                    {
                        location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                    }
                    MapArray[location.Y, location.X] = new MultiKey(this, location);
                }
            }
            // Generating and placing keys.
            if (NumberOfMultiKeys == 0)
            {
                for (int i = 0; i < NumberOfKeys; i++)
                {
                    var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                    while (GetGameObjectAt(location).GetType() != typeof(Floor))
                    {
                        location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                    }
                    MapArray[location.Y, location.X] = new Key(this, location);
                }
            }
            // Generating and placing traps.
            for (int i = 0; i < NumberOfTraps; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                while (GetGameObjectAt(location).GetType() != typeof(Floor))
                {
                    location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                }
                MapArray[location.Y, location.X] = new Trap(random.Next(1, 5), this, location);
            }
            // Generating and placing prizes.
            for (int i = 0; i < NumberOfPrizes; i++)
            {
                var location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                while (GetGameObjectAt(location).GetType() != typeof(Floor))
                {
                    location = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
                }
                MapArray[location.Y, location.X] = new Prize(random.Next(5, 10), this, location);
            }

            // Generating and placing player.
            var newPosition = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));

            while (GetGameObjectAt(newPosition).GetType() != typeof(Floor))
            {
                newPosition = new Point(random.Next(1, size.Width - 2));
            }
            newPosition = new Point(3, 5);
            Game.Player = new Player(this, newPosition);
            MapArray[newPosition.Y, newPosition.X] = Game.Player;
            CurrentPlayerLocation = newPosition;
            newPosition = new Point(random.Next(1, size.Width - 2), random.Next(1, size.Height - 2));
        }

        public void MovePlayerInMap(Point currentLocation, Point futureLocation)
        {
            var player = MapArray[currentLocation.Y, currentLocation.X];
            ResetAtLocation(currentLocation);
            MapArray[futureLocation.Y, futureLocation.X] = player;
        }

        public void ResetAtLocation(Point point)
        {
            MapArray[point.Y, point.X] = new Floor(this, point);
        }

        public bool IsDamageDealer(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Monster) || GetGameObjectAt(Point).GetType() == typeof(Trap);
        public bool IsDoor(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Door);
        public bool IsWall(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Wall);
        public bool IsFloor(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Floor);
        public bool IsKey(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Key);
        public bool IsMultiKey(Point Point) => GetGameObjectAt(Point).GetType() == typeof(MultiKey);
        public bool IsPrize(Point Point) => GetGameObjectAt(Point).GetType() == typeof(Prize);

    }
}