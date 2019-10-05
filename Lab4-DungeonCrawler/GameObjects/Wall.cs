using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Wall : GameObject
    {
        public Wall(DungeonMap map, Point location) : base(map, location) { }
        public override char Visual { get; set; } = '#';
    }
}