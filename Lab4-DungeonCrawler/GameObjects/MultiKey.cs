using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class MultiKey : GameObject
    {
        public MultiKey(DungeonMap map, Point location) : base(map, location) { }

        public override char Visual { get; set; } = 'K';
        public int UsesLeft { get; set; } = 2;
    }
}