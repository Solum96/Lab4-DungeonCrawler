using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Player : GameObject
    {
        public override char Visual { get; set; } = '@';
        public int StepCounter { get; set; } = 0;
        public bool HasKey { get; set; } = false;
        public bool HasMultiKey { get; set; } = false;
        public MultiKey MultiKey;

        public Player(DungeonMap map, Point location) : base(map, location)
        {
            try
            {
                StepCounter = Game.Player.StepCounter;
            }
            catch
            {
                StepCounter = 0;
            }
            Location = map.CurrentPlayerLocation;
            if (HasMultiKey)
            {
                this.MultiKey = Game.Player.MultiKey;
            }
        }
    }
}