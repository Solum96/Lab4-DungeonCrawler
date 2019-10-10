using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Player : GameObject
    {
        public override char Visual { get; set; } = '@';
        public static int StepCounter { get; set; } = 0;
        public bool HasKey { get; set; } = false;
        public static bool HasMultiKey { get; set; } = false;

        public Player(DungeonMap map, Point location) : base(map, location)
        {
            Location = map.CurrentPlayerLocation;
        }
    }
}