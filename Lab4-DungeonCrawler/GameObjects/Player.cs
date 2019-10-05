using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Player : GameObject
    {
        public override char Visual { get; set; } = '@';
        public int StepCounter { get; set; }
        public bool HasKey { get; set; } = false;

        public Player(DungeonMap map, Point location):base(map, location)
        {
            Location = map.CurrentPlayerLocation;
        }

        public void MovePlayer(MoveDelta moveDelta, Monster monster)
        {
            Point futureLocation = new Point { Y = this.Location.Y + moveDelta.DeltaY, X = this.Location.X + moveDelta.DeltaX };

            if (DungeonMap.IsDoor(futureLocation) && this.HasKey)
            {
                DungeonMap.MovePlayerInMap(Location, futureLocation);
                this.Location = futureLocation;
                return;
            }

            if (DungeonMap.IsMonster(futureLocation))
            {
                DungeonMap.MovePlayerInMap(Location, futureLocation);
                StepCounter += monster.Damage;
                this.Location = futureLocation;
                return;
            }

            if (DungeonMap.IsWall(futureLocation))
            {
                return;
            }

            if(DungeonMap.IsKey(futureLocation))
            {
                DungeonMap.MovePlayerInMap(Location, futureLocation);
                HasKey = true;
                Location = futureLocation;
                return;
            }
        }
    }
}