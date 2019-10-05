using System.Drawing;

namespace Lab4_DungeonCrawler.GameObjects
{
    public class Key : GameObject
    {
        public Key(DungeonMap map, Point location) : base(map, location) { }

        public override char Visual { get; set; } = 'k';
    }
}