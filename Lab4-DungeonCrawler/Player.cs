namespace Lab4_DungeonCrawler
{
    public class Player
    {
        public int StepCounter { get; set; }
        public bool HasKey { get; set; } = false;
        public Coordinate Location { get; set; } = new Coordinate();
        private Map Map { get; set; }

        public Player(Map map)
        {
            Map = map;
            Location = map.CurrentPlayerLocation;
        }

        public void MovePlayer(MoveDelta moveDelta, Monster monster)
        {
            Coordinate futureLocation = new Coordinate { RowIndex = this.Location.RowIndex + moveDelta.DeltaY, ColumnIndex = this.Location.ColumnIndex + moveDelta.DeltaX };

            if (Map.IsDoor(futureLocation) && this.HasKey)
            {
                this.Location = futureLocation;
                return;
            }

            if (Map.IsMonster(futureLocation))
            {
                StepCounter += monster.Damage;
                this.Location = futureLocation;
                return;
            }

            if (Map.IsWall(futureLocation))
            {
                return;
            }
        }
    }
}