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
            FindStartLocation();
        }

        public void MovePlayer(MoveDelta moveDelta, Monster monster)
        {
            

            if(Map.IsDoor(this.Location.RowIndex + y, this.Location.ColumnIndex + x) && this.HasKey)
            {
                
            }

            if (Map.IsMonster(rowIndex + y, columnIndex + x))
            {
                StepCounter += monster.Damage;
            }

            if (mapArray[rowIndex + y, columnIndex + x] != '#')
            {
                mapArray[rowIndex, columnIndex] = '-';
                mapArray[rowIndex + y, columnIndex + x] = '@';
                StepCounter++;
            }
        }
    }
}