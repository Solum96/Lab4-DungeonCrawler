using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Trap : GameObject
    {
        public Trap(DungeonMap map, Point location) : base(map, location) { }
        public override char Visual { get; set; } = '-';
    }
}