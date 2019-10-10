using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Player : GameObject
    {
        public override char Visual { get; set; } = '@';
        public static int StepCounter { get; set; } = 0;
        public bool HasKey { get; set; } = false;
        public bool HasMultiKey { get; set; } = false;

        public Player(DungeonMap map, Point location):base(map, location)
        {
            Location = map.CurrentPlayerLocation;
        }

        public string MovePlayer(MoveDelta moveDelta)
        {
            Point futureLocation = new Point (Location.X + moveDelta.DeltaX, Location.Y + moveDelta.DeltaY);

            if (Map.IsDoor(futureLocation) && this.HasKey || Map.IsDoor(futureLocation) && this.HasMultiKey && MultiKey.UsesLeft > 0)
            {
                StepCounter++;
                HasKey = false;
                if (MultiKey.UsesLeft == 0) { HasMultiKey = false; }
                MultiKey.UsesLeft--;
                Map.GenerateMap(Map.MapSize);
                //Map.MovePlayerInMap(Location, futureLocation);
                return "Used key on door.\r\nEntering new room.";
            }

            if (Map.IsDoor(futureLocation) && !HasKey)
            {
                return "You don't have a key.";
            }

            if (Map.IsMonster(futureLocation))
            {
                var damage = (Map.GetGameObjectAt(futureLocation) as Monster).Damage;
                StepCounter += damage;
                Map.MovePlayerInMap(Location, futureLocation);

                Location = futureLocation;
                return $"Battle ensues! You lost (as always), and got punished with {damage} steps.";
            }

            if (Map.IsTrap(futureLocation))
            {
                var trapDamage = (Map.GetGameObjectAt(futureLocation) as Trap).TrapDamage;
                StepCounter += trapDamage;
                Map.MovePlayerInMap(Location, futureLocation);

                Location = futureLocation;
                return $"Your foot gets impaled by a spike. Ouch. You'r punished with {trapDamage} steps.";
            }

            if (Map.IsPrize(futureLocation))
            {
                var value = (Map.GetGameObjectAt(futureLocation) as Prize).Value;
                StepCounter -= value;
                StepCounter = StepCounter < 0 ? 0 : StepCounter;
                Map.MovePlayerInMap(Location, futureLocation);
                Location = futureLocation;
                return $"Battle ensues! You lost (as always), and got punished with {value} steps.";
            }

            if (Map.IsWall(futureLocation))
            {
                return "Stop banging your head against the wall. It's not helping anyone.";
            }

            if (Map.IsKey(futureLocation))
            {
                Map.MovePlayerInMap(Location, futureLocation);
                HasKey = true;
                StepCounter++;
                Location = futureLocation;
                return "You found a key! Well done!";
            }
            Map.MovePlayerInMap(Location, futureLocation);
            Location = futureLocation;
            StepCounter++;
            return "";
        }
    }
}