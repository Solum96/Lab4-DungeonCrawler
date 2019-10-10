namespace Lab4_DungeonCrawler
{
    public class MoveDelta
    {
        private int deltaX = 0;
        private int deltaY = 0;
        // Movement values. Getting and setting with a shorthand.
        public int DeltaY
        {
            get { return deltaX; }
            set
            {
                deltaX = value >= 1 ? 1 : value <= -1 ? -1 : 0;
            }
        }

        public int DeltaX
        {
            get { return deltaY; }
            set
            {
                deltaY = value >= 1 ? 1 : value <= -1 ? -1 : 0;
            }
        }
    }
}